using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SampleApp.Data;
using SampleApp.Messages;
using SampleApp.Model;

namespace SampleApp.ViewModel
{
    public class BasketViewModel : ViewModelBase
    {
        private IBasketModel _basketModel;


        public BasketViewModel(IBasketModel basketModel)
        {
            _basketModel = basketModel;
        }


        public IBasketModel BasketModel
        {
            get { return _basketModel; }
        }
    }
}
