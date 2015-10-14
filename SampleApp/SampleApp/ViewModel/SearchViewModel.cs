using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SampleApp.Messages;

namespace SampleApp.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        private string _searchTerm;

        public SearchViewModel(IMessenger messenger)
        {
            MessengerInstance = messenger;
        }

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                if (_searchTerm == value)
                    return;

                _searchTerm = value;
                RaisePropertyChanged(() => this.SearchTerm);
                MessengerInstance.Send(new SearchMessage(value));
            }
        }
    }
}
