
using Project.ControllerInterface;
using Project.Database;
using Project.Enum;
using Project.Models;
using Project.Views;

namespace Project.Controller
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
                if(user.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && user.Password.Equals(password))
                {
                    return user;
                }
            }
            return null;
        }
         public void Register(User user, Role role) 
         {
            UserDbHandler.UserDbInstance.AddUser(user); 

        }
        public void Logout()
        {
            Program.Main(new string[0]);
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
