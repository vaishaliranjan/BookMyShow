
using Project.ControllerInterface;
using Project.DatabaseInterface;
using Project.Enum;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class AuthController: IAuthController
    {
        public IUserDbHandler UserDbHandler { get; }

        public AuthController(IUserDbHandler userDbHandler)
        {
            UserDbHandler = userDbHandler;
        }
    
      
        public User Login(string username, string password)
        {
            List<User> allUsers = UserDbHandler.ListOfUsers;
            foreach (User user in allUsers)
            {
                if(user.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && user.Password.Equals(password))
                {
                    return user;
                }
            }
            return null;
        }
         public bool Register(User user, Role role) 
         {
            return UserDbHandler.AddUser(user); 

         }
        public void Logout()
        {
            Program.Main(new string[0]);
        }

        public bool ValidateUser(string username)
        {
            var users = UserDbHandler.ListOfUsers;
            var user = users.SingleOrDefault(u => u.Username.ToLower().Equals(username.ToLower()));
            if(user == null)
            {
                return true;
            }
            return false;
        }

       
    }
}
