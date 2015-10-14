using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SampleApp.Data;

namespace SampleApp.Model
{
    /// <summary>
    /// ViewModel for products that are contained in the basket
    /// </summary>
    public class BasketItem : ViewModelBase
    {
        private int _count;

        public BasketItem(Product product)
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
