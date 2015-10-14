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
        private ObservableCollection<BasketItem> _products = new ObservableCollection<BasketItem>();
        private double _total;


        public BasketViewModel(IMessenger messenger)
        {
            // Design Mode
            if (this.IsInDesignMode)
            {
                var product = new Product();
                product.Name = "Product";
                product.Price = 250;

                _products.Add(new BasketItem(product));
                _products.Add(new BasketItem(product));
                _products.Add(new BasketItem(product));
                _products.Add(new BasketItem(product));

                Total = 1000;
            }

            // Unpack
            MessengerInstance = messenger;

            // Event Subscriptions
            messenger.Register<AddProductMessage>(this, AddProductHandler);
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


        private void AddProductHandler(AddProductMessage message)
        {
            var existingProduct = _products.SingleOrDefault(p => p.Product.Equals(message.Product));
            if (existingProduct != null)
            {
                existingProduct.Count += 1;
            }
            else
            {
                _products.Add(new BasketItem(message.Product));
            }

            Total = _products.Sum(p => p.Count * p.Product.Price);
        }
    }
}
