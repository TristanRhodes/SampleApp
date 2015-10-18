using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SampleApp.Data;

namespace SampleApp.Model
{
    public interface IBasketItemModel
    {
        int Count { get; }

        Product Product { get; }
    }

    /// <summary>
    /// ViewModel for products that are contained in the basket
    /// </summary>
    public class BasketItemModel : ModelBase, IBasketItemModel
    {
        private int _count;

        public BasketItemModel(Product product)
        {
            Product = product;
            Count = 1;
        }

        public int Count
        {
            get { return _count; }
            set
            {
                if (_count == value)
                    return;

                _count = value;
                RaisePropertyChanged(() => this.Count);
            }
        }

        public Product Product { get; private set; }
    }
}
