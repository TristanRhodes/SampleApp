using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SampleApp.Data;
using SampleApp.Messages;

namespace SampleApp.ViewModel
{
    public class ProductPreviewViewModel : ViewModelBase
    {
        private bool _visible;
        private Data.Product _product;

        
        public ProductPreviewViewModel(IMessenger messenger)
        {
            // Design setup
            if (this.IsInDesignMode)
            {
                Visible = true;

                Product = new Product()
                {
                    ProductId=12345,
                    Name = "Product Name",
                    Description = "Product Description",
                    UpdatedDate = DateTime.Today,
                };
            }

            // Unpack
            MessengerInstance = messenger;

            // Event Registration
            MessengerInstance.Register<ProductPreviewMessage>(this, HandleProductPreview);

            // Commands
            CloseCommand = new RelayCommand(CloseExecute);
            AddProductCommand = new RelayCommand(AddProductExecute);
        }


        public ICommand CloseCommand { get; private set; }

        public ICommand AddProductCommand { get; private set; }


        public bool Visible
        {
            get { return _visible; }
            set
            {
                if (_visible == value)
                    return;

                _visible = value;
                RaisePropertyChanged(() => this.Visible);
            }
        }

        public Product Product
        {
            get { return _product; }
            set
            {
                if (_product == value)
                    return;

                _product = value;
                RaisePropertyChanged(() => this.Product);
            }
        }


        private void HandleProductPreview(ProductPreviewMessage msg)
        {
            Visible = true;
            Product = msg.Product;
        }

        private void CloseExecute()
        {
            this.Visible = false;
        }

        private void AddProductExecute()
        {
            Visible = false;
            MessengerInstance.Send(new AddProductMessage(Product));
        }
    }
}
