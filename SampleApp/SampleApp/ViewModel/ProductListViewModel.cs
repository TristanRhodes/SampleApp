using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SampleApp.Data;
using SampleApp.Messages;
using SampleApp.Services;

namespace SampleApp.ViewModel
{
    public class ProductListViewModel : ViewModelBase
    {
        // Services
        private IProductsService _productService;

        // Property Backers
        private IEnumerable<Product> _products;


        public ProductListViewModel(IMessenger messenger, IProductsService productService)
        {
            // Design Setup
            if (this.IsInDesignMode)
            {
                var product = new Product();
                product.ProductId = 1;
                product.Name = "Product";
                product.Price = 100;

                Products = new Product[] { product, product, product, product, product, product };
            }

            // Unpack
            _productService = productService;
            MessengerInstance = messenger;

            // Events
            MessengerInstance.Register<SearchMessage>(this, HandleSearch);

            // Commands
            ViewProductCommand = new RelayCommand<Product>(ViewProductExecute);
        }


        public ICommand ViewProductCommand { get; private set; }

        public IEnumerable<Product> Products
        {
            get { return _products; }
            private set
            {
                if (_products == value)
                    return;

                _products = value;
                RaisePropertyChanged(() => this.Products);
            }
        }


        private void HandleSearch(SearchMessage message)
        {
            Task.Run(() => PerformSearch(message.SearchTerm))
                .ContinueWith(PerformSearchComplete);
        }

        private IEnumerable<Product> PerformSearch(string searchTerm)
        {
            return _productService.GetProducts(searchTerm);
        }

        private void PerformSearchComplete(Task<IEnumerable<Product>> task)
        {
            Products = task.Result;
        }


        private void ViewProductExecute(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();

            MessengerInstance.Send(new ProductPreviewMessage(product));
        }
    }
}
