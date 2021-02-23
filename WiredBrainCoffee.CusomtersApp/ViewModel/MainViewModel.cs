using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CusomtersApp.Base;
using WiredBrainCoffee.CusomtersApp.DataProvider;
using WiredBrainCoffee.CusomtersApp.Models;

namespace WiredBrainCoffee.CusomtersApp.ViewModel
{
    public class MainViewModel: Observable
    {
        
        private ICustomerDataProvider _customerDataProvider;
        private Customer _selectedCustomer;

        public MainViewModel(ICustomerDataProvider customerDataProvider )
        {
            
            _customerDataProvider = customerDataProvider;
            Customers = new ObservableCollection<Customer>();
        }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value )
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();
                }
            }
        }


        public ObservableCollection<Customer> Customers { get; }
        public async Task LoadAsync()
        {
            Customers.Clear();
            var customers = await _customerDataProvider.LoadCustomers();
            foreach (var c in customers)
            {
                Customers.Add(c);
            }
        }

        public void Save()
        {
            _customerDataProvider.SaveCustomers(Customers);
        }
    }
}
