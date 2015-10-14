using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SampleApp.Data;

namespace SampleApp.Model
{
    public interface IBasket
    {

    }

    public class Basket : ViewModelBase, IBasket
    {
        private IMessenger _messenger;
        private ObservableCollection<BasketItem> _products = new ObservableCollection<BasketItem>();
        private double _total;


        public Basket(IMessenger messeger)
        {
            _messenger = messeger;
        }

        public IEnumerable<BasketItem> Items
        {
            get { return _products; }
        }

        public double Total
        {
            get { return _total; }
            set
            {
                if (_total == value)
                    return;

                _total = value;
                RaisePropertyChanged(() => this.Total);
            }
        }
    }
}
