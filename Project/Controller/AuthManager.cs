
using Project.Database;
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
        public static int userIDInc = 28;
        public User Login(string username, string password)
        {
            List<User> allUsers = UserDbHandler.UserDbInstance.listOfUsers;
            foreach (User user in allUsers)
            {
                if(user.Username == username && user.Password== password)
                {
                    if (user.role == Role.Admin)
                    {
                        return (Admin)user;
                    }
                    else if (user.role == Role.Organizer)
                    {
                        return (Organizer)user;
                    }
                    else if (user.role == Role.Customer)
                    {
                        return (Customer)user;
                    }
                }
                
            }
            return null;

        }
      
         public  bool Register(string name, string username, string email, string password, Role roleInput)
         {
            if (ValidateUser(username))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-                  USER ALREADY EXISTS!                     -");
                Console.WriteLine("-------------------------------------------------------------");
                Console.ResetColor();
                return false;
            }

            else
            {
                    var newUser = new T
                    {
                        UserId = userIDInc,
                        Name = name,
                        Username = username,
                        Email = email,
                        Password = password,
                        role = (Role)roleInput,
                    };
                    userIDInc++;

                    UserDbHandler.UserDbInstance.AddEntry(newUser);
                    return true;
                
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
