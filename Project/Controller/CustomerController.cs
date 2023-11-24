using Project.ControllerInterface;
using Project.DatabaseInterface;
using Project.Enum;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class CustomerController: ICustomerController 
    {
        public IUserDbHandler UserDbHandler { get; }

        public CustomerController(IUserDbHandler userDbHandler)
        {
            UserDbHandler = userDbHandler;
        }
        public User GetByUsername(string username)
        {
            var users = UserDbHandler.ListOfUsers;
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
            var users = UserDbHandler.ListOfUsers;
            List<User> Customers=null;
            if (users != null)
            {
                 Customers = users.FindAll(u => u.Role == Role.Customer);
            }
            return Customers;
        }
    }
}
