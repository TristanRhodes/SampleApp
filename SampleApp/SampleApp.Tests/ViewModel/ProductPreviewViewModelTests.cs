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
using SampleApp.Model;
using SampleApp.ViewModel;

namespace SampleApp.Tests.ViewModel
{
    [TestFixture]
    public class ProductPreviewViewModelTests
    {
        private Mock<IMessenger> _messengerMock;
        private Mock<IBasketModel> _basketModelMock;
        private ProductPreviewViewModel _viewModel;

        private Action<ProductPreviewMessage> _previewHandle;

        [SetUp]
        public void Setup()
        {
            _messengerMock = new Mock<IMessenger>();
            _basketModelMock = new Mock<IBasketModel>();

            _messengerMock
                .Setup(m => m.Register<ProductPreviewMessage>(It.IsAny<ProductPreviewViewModel>(), It.IsAny<Action<ProductPreviewMessage>>()))
                .Callback<object, Action<ProductPreviewMessage>>((o, a) => _previewHandle = a);

            _viewModel = new ProductPreviewViewModel(_messengerMock.Object, _basketModelMock.Object);
        }

        [Test]
        public void ShouldBecomeVisibleAndContainProductWhenAProductPreviewMessageIsRecieved()
        {
            var product = new Product();
            Assert.IsFalse(_viewModel.Visible);
            Assert.IsNull(_viewModel.Product);

            _previewHandle(new ProductPreviewMessage(product));

            Assert.IsTrue(_viewModel.Visible);
            Assert.AreEqual(product, _viewModel.Product);
        }

        [Test]
        public void ShouldBecomeHiddenWhenTheCloseCommandIsExecuted()
        {
            _viewModel.Visible = true;

            _viewModel.CloseCommand.Execute(null);

            Assert.IsFalse(_viewModel.Visible);
        }

        [Test]
        public void ShouldAddProductToBasketWhenAddProductCommandIsExecuted()
        {
            var product = new Product();

            _viewModel.Product = product;

            _basketModelMock
                .Setup(m => m.AddItem(product, 1))
                .Verifiable();

            _viewModel.AddProductCommand.Execute(null);

            _basketModelMock
                .Verify();
        }
    }
}
