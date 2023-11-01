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
    internal class AdminDbHandler: DbHandler
    {
        private static AdminDbHandler adminDbInstance;
        private static string _user_path;
        public List<Admin> listOfAdmins { get; set; }
        public static AdminDbHandler AdminDbInstance
        {
            get
            {
                if (adminDbInstance == null)
                {
                    adminDbInstance = new AdminDbHandler();
                }
                return adminDbInstance;
            }
        }

        private AdminDbHandler()
        {
            listOfAdmins = new List<Admin>();
            //List<User> listOfUsers = UserDbHandler.UserDbInstance.listOfUsers;
            //listOfCustomers= listOfUsers.FindAll(u=> u.role == Role.Customer);

            _user_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Users.json";

            try
            {
                string userFileContent = File.ReadAllText(_user_path);
                List<Admin> listOfUsers = JsonConvert.DeserializeObject<List<Admin>>(userFileContent)!;
                listOfAdmins = listOfUsers.FindAll(u => u.role == Role.Admin);
            }
            catch
            {
                Error.UnexpectedError();
            }
        }
        public override bool AddEntry(object obj)
        {
            if (obj is Admin)
            {
                listOfAdmins.Add((Admin)obj);
                if (UpdateEntry<Admin>(_user_path, listOfAdmins))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
