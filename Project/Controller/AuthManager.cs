
using Project.Database;
using Project.Models;
using Project.UILayer;


namespace Project.BusinessLayer
{
    public class AuthManager
    {
        private static AuthManager _authManagerObject=null;
        private AuthManager(){}
        public static AuthManager AuthObject
        {
            get
            {
                if(_authManagerObject == null)
                {
                    _authManagerObject = new AuthManager();
                }
                return _authManagerObject;
            }
        }
        public static int userIDInc = UserDbHandler.UserDbInstance.listOfUsers[UserDbHandler.UserDbInstance.listOfUsers.Count-1].UserId;
        public User Login(string username, string password)
        {
            List<User> allUsers = UserDbHandler.UserDbInstance.listOfUsers;
            foreach (User user in allUsers)
            {
                if(user.Username == username && user.Password== password)
                {
                    return user;
                }
            }
            return null;
        }
         public  void Register(User user, Role role) 
         {
            if (role == Role.Admin)
            {
                AdminDbHandler.AdminDbInstance.AddAdmin((Admin)user);
                UserDbHandler.UserDbInstance.AddUser(user);
            }
            else if (role == Role.Organizer)
            {
                OrganizerDbHandler.OrganizerDbInstance.AddOrganizer((Organizer)user);
                UserDbHandler.UserDbInstance.AddUser(user);
            }
            else if (role == Role.Customer)
            {
                CustomerDbHandler.CustomerDbInstance.AddCustomer((Customer)user);
                UserDbHandler.UserDbInstance.AddUser(user);
            }

        }
        public void Logout()
        {
            HomePage.HomePageFunction();
        }

        public bool ValidateUser(string uname)
        {
            var users = UserDbHandler.UserDbInstance.listOfUsers;
            foreach (User user in users)
            {
                if (user.Username == uname)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
