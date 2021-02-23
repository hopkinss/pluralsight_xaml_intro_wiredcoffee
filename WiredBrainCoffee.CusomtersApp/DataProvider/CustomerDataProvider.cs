using System;
using System.Collections.Generic;
using System.Text;
using WiredBrainCoffee.CusomtersApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace WiredBrainCoffee.CusomtersApp.DataProvider
{
    public class CustomerDataProvider : ICustomerDataProvider
    {
        public Task<IEnumerable<Customer>> LoadCustomers()
        {
            IEnumerable<Customer> result;
            using (var c = new CoffeeShopContext())
            {

                result = c.CoffeeCustomers.Select(x => new Customer
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    IsDeveloper = x.IsDeveloper
                }).ToList();
            }
            return Task.FromResult(result);
        }

        public void SaveCustomers(IEnumerable<Customer> customers)
        {
            using (var c = new CoffeeShopContext())
            {
                var r = c.CoffeeCustomers;
                c.CoffeeCustomers.RemoveRange(r);
                c.CoffeeCustomers.AddRange(customers.Select(x => new Customer
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    IsDeveloper = x.IsDeveloper
                }));
                c.SaveChanges();
            }
        }
    }
}
