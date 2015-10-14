using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using SampleApp.Messages;
using SampleApp.ViewModel;

namespace SampleApp.View
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductListView : UserControl
    {
        public ProductListView()
        {
            InitializeComponent();

            // Raise the notification event here so it defaults to load
            Messenger.Default.Send(new SearchMessage(string.Empty));
        }

        private ProductListViewModel ViewModel
        {
            get { return (ProductListViewModel)DataContext; }
        }

        //TODO: Move to routed command
        private void View_Click(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;

            ViewModel.ViewProductCommand.Execute(element.DataContext);
        }
    }
}