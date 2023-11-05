using Newtonsoft.Json;
using Project.Models;
using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database
{
    internal class CustomerDbHandler : DbHandler<Customer>
    {
        private static CustomerDbHandler? customerDbInstance;
        private static string? _user_path;
        public List<Customer> listOfCustomers { get; set; }
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
            listOfCustomers = new List<Customer>();
            _user_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Users.json";

            try
            {
                string userFileContent = File.ReadAllText(_user_path);
                List<Customer> listOfUsers = JsonConvert.DeserializeObject<List<Customer>>(userFileContent)!;
                listOfCustomers= listOfUsers.FindAll(u=> u.role==Role.Customer);
            }
            catch
            {
                Error.UnexpectedError();
            }
        }
        public bool AddCustomer(Customer customer)
        {
            if (AddEntry(customer, listOfCustomers, _user_path))
                return true;
            return false;
        }
    }
}
