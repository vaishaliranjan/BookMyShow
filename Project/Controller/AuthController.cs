
using Project.ControllerInterface;
using Project.Database;
using Project.Enum;
using Project.Models;
using Project.UILayer;


namespace Project.BusinessLayer
{
    public class AuthController: IAuthController
    {
        private static AuthController _authManagerObject=null;
        private AuthController(){}
        public static AuthController AuthObject
        {
            get
            {
                if(_authManagerObject == null)
                {
                    _authManagerObject = new AuthController();
                }
                return _authManagerObject;
            }
        }
      
        public User Login(string username, string password)
        {
            List<User> allUsers = UserDbHandler.UserDbInstance.ListOfUsers;
            foreach (User user in allUsers)
            {
                if(user.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && user.Password.ToLower().Equals(password.ToLower()))
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

        public bool ValidateUser(string username)
        {
            var users = UserDbHandler.UserDbInstance.ListOfUsers;
            foreach (User user in users)
            {
                if (user.Username.ToLower().Equals(username.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
