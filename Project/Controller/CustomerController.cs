using Project.ControllerInterface;
using Project.Database;
using Project.Enum;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class CustomerController: ICustomerController 
    {

        public User GetByUsername(string username)
        {
            var users = UserDbHandler.UserDbInstance.ListOfUsers;
            var Customers = users.FindAll(u => u.Role == Role.Customer);
            if (Customers != null)
            {
                User customer = null;
                try
                {
                    customer = Customers.Single(u => u.Username.ToLower().Equals(username.ToLower()));
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

        public List<User> GetAll()
        {
            var users = UserDbHandler.UserDbInstance.ListOfUsers;
            var Customers = users.FindAll(u => u.Role == Role.Customer);
            return Customers;
        }
    }
}
