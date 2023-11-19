using Newtonsoft.Json;
using Project.Models;
using Project.Controller;
using Project.Views;
using Project.DatabaseInterface;

namespace Project.Database
{
    
    public class UserDbHandler : DbHandler<User>, IUserDbHandler
    {
        private static UserDbHandler userDbInstance;
        private static string _user_path;
        public List<User> ListOfUsers { get; set; }
        public static UserDbHandler UserDbInstance
        {
            get
            {
                if (userDbInstance == null)
                {
                    userDbInstance = new UserDbHandler();
                }
                return userDbInstance;
            }
        }
        private UserDbHandler()
        {
            ListOfUsers = new List<User>();
             _user_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Project\Files\Users.json";

            try
            {
                string userFileContent = File.ReadAllText(_user_path);
                ListOfUsers = JsonConvert.DeserializeObject<List<User>>(userFileContent)!;
            }
            catch(Exception ex) 
            {
                Error.UnexpectedError();
                HelperClass.LogException(ex, "An error occurred while reading the json.");
            }
    }

        public bool AddUser(User user)
        {
            if (AddEntry(user, ListOfUsers, _user_path))
                return true;
            return false;
        }


    }
}
