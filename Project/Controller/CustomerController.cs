using Project.ControllerInterface;
using Project.Database;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class CustomerController: ICustomerController 
    {
        public Customer GetByUsername(string username)
        {
            List<Customer> customers = CustomerDbHandler.CustomerDbInstance.ListOfCustomers;
            if (customers != null)
            {
                Customer customer = null;
                try
                {
                    customer = customers.Single(u => u.Username.ToLower().Equals(username.ToLower()));
                    return customer;
                }
                catch (Exception ex)
                {
                    HelperClass.LogException(ex, "More than one customer with same username.");
                    return customer;
                }
            }
            else
            {
                return null;
            }
        }

        public List<Customer> GetAll()
        {
            return  CustomerDbHandler.CustomerDbInstance.ListOfCustomers;
            
        }
    }
}
