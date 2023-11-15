using Newtonsoft.Json;
using Project.Models;
using Project.Controller;
using Project.Enum;
using Project.Views;

namespace Project.Database
{
    public class AdminDbHandler: DbHandler<Admin>
    {
        private static AdminDbHandler adminDbInstance;
        private static string _user_path;
        public List<Admin> ListOfAdmins { get; set; }
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
            ListOfAdmins = new List<Admin>();
            

            _user_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Project\Files\Users.json";

            try
            {
                string userFileContent = File.ReadAllText(_user_path);
                List<Admin> listOfUsers = JsonConvert.DeserializeObject<List<Admin>>(userFileContent)!;
                ListOfAdmins = listOfUsers.FindAll(u => u.Role == Role.Admin);
            }
            catch(Exception ex) 
            {
                Error.UnexpectedError();
                HelperClass.LogException(ex, "An error occurred while reading the json.");
            }
        }
       
        public bool AddAdmin(Admin admin)
        {
            if(AddEntry(admin,ListOfAdmins, _user_path))
                return true;
            return false;
        }
        
    }
}
