using System.Collections.Generic;
using System.Threading.Tasks;
using WiredBrainCoffee.CusomtersApp.Models;

namespace WiredBrainCoffee.CusomtersApp.DataProvider
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>> LoadCustomers();
        void SaveCustomers(IEnumerable<Customer> customers);
    }
}