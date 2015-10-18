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
    public interface IBasketModel
    {
        void AddItem(Product product, int count = 1);

        IEnumerable<IBasketItemModel> Items { get; }

        double Total { get; }
    }

    public class BasketModel : ModelBase, IBasketModel
    {
        private ObservableCollection<BasketItemModel> _products = new ObservableCollection<BasketItemModel>();
        private double _total;


        public BasketModel()
        {
            // Design Mode
            if (this.IsInDesignMode)
            {
                AddItem(new Product() { Name = "Product 1", Price = 250});
                AddItem(new Product() { Name = "Product 1", Price = 250});
                AddItem(new Product() { Name = "Product 1", Price = 250});
                AddItem(new Product() { Name = "Product 1", Price = 250});
            }
        }


        public void AddItem(Product product, int count = 1)
        {
            var existingProduct = _products.SingleOrDefault(p => p.Product.Equals(product));
            if (existingProduct != null)
            {
                existingProduct.Count += count;
            }
            else
            {
                _products.Add(new BasketItemModel(product));
            }

            Total = _products.Sum(p => p.Count * p.Product.Price);
        }

        public IEnumerable<IBasketItemModel> Items
        {
            get { return _products; }
        }

        public double Total
        {
            get { return _total; }
            private set
            {
                if (_total == value)
                    return;

                _total = value;
                RaisePropertyChanged(() => this.Total);
            }
        }
    }
}
