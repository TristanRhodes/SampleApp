/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WpfImageSplicer"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using SampleApp.Services;

namespace SampleApp.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Reset();

                // Create design time view services and models
                // SimpleIoc.Default.Register<IDataService, DesignDataService>();
            }
            else
            {
                // Create run time view services and models
            }

            // Messenger setup
            var messenger = new Messenger();
            Messenger.OverrideDefault(messenger);

            // Components
            SimpleIoc.Default.Register<IMessenger>(() => messenger);

            // Services
            SimpleIoc.Default.Register<IProductsService, ProductsService>();

            // View Models     
            SimpleIoc.Default.Register<ProductListViewModel>();
            SimpleIoc.Default.Register<ProductPreviewViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<BasketViewModel>();
        }


        public SearchViewModel Search
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchViewModel>();
            }
        }

        public ProductListViewModel ProductList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProductListViewModel>();
            }
        }

        public ProductPreviewViewModel ProductPreview
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProductPreviewViewModel>();
            }
        }

        public BasketViewModel Basket
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BasketViewModel>();
            }
        }


        public static void Cleanup()
        {
            // TODO: Clear the ViewModels
        }
    }
}