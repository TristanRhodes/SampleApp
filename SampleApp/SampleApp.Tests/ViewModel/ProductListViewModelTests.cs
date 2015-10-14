using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Moq;
using NUnit.Framework;
using SampleApp.Data;
using SampleApp.Messages;
using SampleApp.Services;
using SampleApp.ViewModel;

namespace SampleApp.Tests.ViewModel
{
    [TestFixture]
    public class ProductListViewModelTests
    {
        private Mock<IProductsService> _productsServiceMock;

        private ProductListViewModel _viewModel;
        private Messenger _messenger;

        [SetUp]
        public void Setup()
        {
            _messenger = new Messenger();

            _productsServiceMock = new Mock<IProductsService>();
            _viewModel = new ProductListViewModel(_messenger, _productsServiceMock.Object);
        }

        [Test]
        public void ShouldLoadProductsWhenSearchEventRecieved()
        {
            var searchTerm = "searchTerm";
            var message = new SearchMessage(searchTerm);
            var products = new List<Product>();
            var product = new Product();

            _productsServiceMock
                .Setup(p => p.GetProducts(searchTerm))
                .Returns(products)
                .Verifiable();

            _messenger.Send(message);
            Utilities.WaitFor(() => _viewModel.Products != null, 5000);

            _productsServiceMock.Verify();
            Assert.AreEqual(products, _viewModel.Products);
        }

        [Test]
        public void ShouldRaiseProductPreviewMessageWhenViewCommandIsExecuted()
        {
            var product = new Product();
            var message = (ProductPreviewMessage)null;

            _messenger.Register<ProductPreviewMessage>(this, m => message = m);

            _viewModel.ViewProductCommand.Execute(product);

            Assert.IsNotNull(message);
            Assert.AreEqual(product, message.Product);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgNullExceptionWhenViewCommandIsExecutedWithNull()
        {
            try
            {
                _viewModel.ViewProductCommand.Execute(null);
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }

            Assert.Fail("Exception not raised");
        }
    }
}
