using Newtonsoft.Json;
using Project.BusinessLayer;
using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database
{
    internal class CustomerDbHandler : DbHandler
    {
        private static CustomerDbHandler customerDbInstance;
        private static string _user_path;
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
            //List<User> listOfUsers = UserDbHandler.UserDbInstance.listOfUsers;
            //listOfCustomers= listOfUsers.FindAll(u=> u.role == Role.Customer);

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
        public override bool AddEntry(object obj)
        {
            if (obj is Customer)
            {
                listOfCustomers.Add((Customer)obj);
                if (UpdateEntry<Customer>(_user_path, listOfCustomers))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
