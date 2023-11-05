
using Project.Database;
using Project.Models;
using Project.UILayer;


namespace Project.BusinessLayer
{
    public class AuthManager<T> where T : User, new()
    {
        private static AuthManager<T> _authManagerObject;
        private AuthManager(){}
        public static AuthManager<T> AuthObject
        {
            get
            {
                if(_authManagerObject == null)
                {
                    _authManagerObject = new AuthManager<T>();
                }
                return _authManagerObject;
            }
        }
        public static int userIDInc = UserDbHandler.UserDbInstance.listOfUsers[-1].UserId;
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
         public  User Register(string name, string username, string email, string password, Role roleInput)
         {
            if (ValidateUser(username))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return null;
            }

            else
            {
                    var newUser = new T
                    {
                        UserId = ++userIDInc,
                        Name = name,
                        Username = username,
                        Email = email,
                        Password = password,
                        role = (Role)roleInput,
                    };
                    

                    UserDbHandler.UserDbInstance.AddUser(newUser);
                    return newUser;
                
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
                    return true;
                }
            }
            return false;
        }
    }
}
