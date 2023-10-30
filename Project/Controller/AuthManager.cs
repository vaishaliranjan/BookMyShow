using Newtonsoft.Json;
using Project.UILayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        public string Login(string un, string pw)
        {
            List<User> allUsers = DatabaseManager.DbObject.ReadUsers();
            foreach (User user in allUsers)
            {
                if(user.Username == un && user.Password== pw)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please wait...");
                    Console.WriteLine();
                    //Thread.Sleep(3000);

                    return user.role.ToString();
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

                    DatabaseManager.DbObject.AddUser(newUser);
                    return true;
                
               
                
            }
            }
        
        public void Logout()
        {
            HomePage.HomePageFunction();
        }

        public bool ValidateUser(string uname)
        {
            var users = DatabaseManager.DbObject.ReadUsers();
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
