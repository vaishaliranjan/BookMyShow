using Newtonsoft.Json;
using Project.Models;
using Project.Controller;

namespace Project.Database
{
    internal class AdminDbHandler: DbHandler<Admin>
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
        public bool AddAdmin(Admin admin)
        {
            if(AddEntry(admin,listOfAdmins, _user_path))
                return true;
            return false;
        }
        
    }
}
