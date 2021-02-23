using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WiredBrainCoffee.CusomtersApp.DataProvider;
using System.ComponentModel;
using System.Linq;
using WiredBrainCoffee.CusomtersApp.Models;
using WiredBrainCoffee.CusomtersApp.ViewModel;

namespace WiredBrainCoffee.CusomtersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainViewModel ViewModel { get; }

        public MainWindow()
        {

            InitializeComponent();
            ViewModel = new MainViewModel(new CustomerDataProvider());
            DataContext = ViewModel;

            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;

        }


        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadAsync();
        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            ViewModel.Save();            
        }




        private void BtnMove_Click(object sender, RoutedEventArgs e)
        {
            var pos = Grid.GetColumn(customerListGrid) == 0 ? 2 : 0;

            Grid.SetColumn(customerListGrid, pos);

            icnMove.Kind = pos == 2 ? MahApps.Metro.IconPacks.PackIconMaterialKind.ArrowLeftThinCircleOutline
                            : icnMove.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.ArrowRightThinCircleOutline;

        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var customer = customerListView.SelectedItem as Customer;
            customerDetailControl.Customer = customer;
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = customerListView.SelectedItem as Customer;
            ViewModel.Customers.Remove(customer);
            ViewModel.SelectedCustomer = null;
        }

        private void BtnAddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer { FirstName = "New" };
            ViewModel.Customers.Add(customer);
            ViewModel.SelectedCustomer = customer;
        }
    }
}
