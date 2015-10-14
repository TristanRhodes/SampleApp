using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Moq;
using NUnit.Framework;
using SampleApp.Messages;
using SampleApp.ViewModel;

namespace SampleApp.Tests.ViewModel
{
    [TestFixture]
    public class SearchViewModelTests
    {
        private Mock<IMessenger> _messengerMock;
        private SearchViewModel _viewModel;

        [SetUp]
        public void Setup()
        {
            _messengerMock = new Mock<IMessenger>();
            _viewModel = new SearchViewModel(_messengerMock.Object);
        }

        [Test]
        public void ShouldRaiseSearchEventWhenTextIsModified()
        {
            var searchTerm = "SearchTerm";
            var message = (SearchMessage)null;

            _messengerMock
                .Setup(m => m.Send<SearchMessage>(It.IsAny<SearchMessage>()))
                .Callback<SearchMessage>(m => message = m);

            _viewModel.SearchTerm = searchTerm;

            Utilities.WaitFor(() => message != null, 5000);

            Assert.IsNotNull(message);
            Assert.AreEqual(message.SearchTerm, searchTerm);
            Assert.AreEqual(_viewModel.SearchTerm, searchTerm);
        }

        [Test]
        public void ShouldNotRaiseSearchEventWhenTextIsSetToSameAsCurrent()
        {
            var searchTerm = "SearchTerm";
            
            _viewModel.SearchTerm = searchTerm;
            Utilities.WaitFor(500);

            _messengerMock
                .Setup(m => m.Send<SearchMessage>(It.IsAny<SearchMessage>()))
                .Throws(new ApplicationException("Should not be called"));

            _viewModel.SearchTerm = searchTerm;
            
            Utilities.WaitFor(500);
            Assert.AreEqual(_viewModel.SearchTerm, searchTerm);
        }
    }
}
