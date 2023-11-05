using Project.Database;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controller
{
    public class CustomerController
    {
        public Customer GetCustomer(string username)
        {
            List<Customer> customers = CustomerDbHandler.CustomerDbInstance.listOfCustomers;
            if (customers != null)
            {
                Customer customer = null;
                try
                {
                    customer = customers.Single(u => u.Username == username);
                    return customer;
                }
                catch (Exception ex)
                {
                    return customer;
                }
            }
            else
            {
                Error.NotFound("customers");
                return null;
            }
        }

        public List<Customer> ViewCustomers()
        {
            return  CustomerDbHandler.CustomerDbInstance.listOfCustomers;
            
        }
    }
}
