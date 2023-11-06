using Project.Database;
using Project.Models;


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
                return null;
            }
        }

        public List<Customer> ViewCustomers()
        {
            return  CustomerDbHandler.CustomerDbInstance.listOfCustomers;
            
        }
    }
}
