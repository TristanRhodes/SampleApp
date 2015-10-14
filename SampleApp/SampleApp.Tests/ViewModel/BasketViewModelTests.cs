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
using SampleApp.ViewModel;

namespace SampleApp.Tests.ViewModel
{
    [TestFixture]
    public class BasketViewModelTests
    {
        private BasketViewModel _viewModel;

        private Mock<IMessenger> _messengerMock;

        private Action<AddProductMessage> _addProductHandle;

        [SetUp]
        public void Setup()
        {
            _messengerMock = new Mock<IMessenger>();

            _messengerMock
                .Setup(m => m.Register<AddProductMessage>(It.IsAny<BasketViewModel>(), It.IsAny<Action<AddProductMessage>>()))
                .Callback<object, Action<AddProductMessage>>((o, a) => _addProductHandle = a);

            _viewModel = new BasketViewModel(_messengerMock.Object);
        }

        [Test]
        public void ShouldAddProductWhenRecievingAddProductEvent()
        {
            var product = new Product();
            _addProductHandle(new AddProductMessage(product));

            Assert.AreEqual(1, _viewModel.Items.Count());
            Assert.AreEqual(product, _viewModel.Items.First().Product);
        }

        [Test]
        public void ShouldIncrementProductCountWhenRecievingAddProductEventForExistingProduct()
        {
            var product1 = new Product() { ProductId = 1 };
            var product2 = new Product() { ProductId = 1 };

            _addProductHandle(new AddProductMessage(product1));
            _addProductHandle(new AddProductMessage(product2));

            Assert.AreEqual(1, _viewModel.Items.Count());

            var productViewModel = _viewModel.Items.First();

            Assert.AreEqual(product1, productViewModel.Product);
            Assert.AreEqual(2, productViewModel.Count);
        }

        [Test]
        public void ShouldUpdateTotalToReflectPriceOfItems()
        {
            var product1 = new Product() { ProductId = 1, Price = 1 };
            var product2 = new Product() { ProductId = 1, Price = 1 };
            var product3 = new Product() { ProductId = 2, Price = 2 };

            _addProductHandle(new AddProductMessage(product1));
            _addProductHandle(new AddProductMessage(product2));
            _addProductHandle(new AddProductMessage(product3));

            Assert.AreEqual(4, _viewModel.Total);
        }
    }
}
