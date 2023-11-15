using Newtonsoft.Json;
using Project.Models;
using Project.Controller;
using Project.Enum;
using Project.Views;

namespace Project.Database
{
    internal class CustomerDbHandler : DbHandler<Customer>
    {
        private static CustomerDbHandler customerDbInstance;
        private static string _user_path;
        public List<Customer> ListOfCustomers { get; set; }
        public static CustomerDbHandler CustomerDbInstance
        {
            get
            {
                if (customerDbInstance == null)
                {
                    customerDbInstance = new CustomerDbHandler();
                }
                return customerDbInstance;
            }
        }

        private CustomerDbHandler()
        {
            ListOfCustomers = new List<Customer>();
            _user_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Project\Files\Users.json";

            try
            {
                string userFileContent = File.ReadAllText(_user_path);
                List<Customer> listOfUsers = JsonConvert.DeserializeObject<List<Customer>>(userFileContent)!;
                ListOfCustomers= listOfUsers.FindAll(u=> u.Role==Role.Customer);
            }
            catch(Exception ex) 
            {
                Error.UnexpectedError();
                HelperClass.LogException(ex, "An error occurred while reading the json.");
            }
        }
        public bool AddCustomer(Customer customer)
        {
            if (AddEntry(customer, ListOfCustomers, _user_path))
                return true;
            return false;
        }
    }
}
