using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer
{
    public static class AuthManager
    {
        public static string Login(string un, string pw)
        {
            List<User> allUsers = DatabaseManager.ReadUsers();
            foreach (User user in allUsers)
            {
                if(user.Username == un && user.Password== pw)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please wait...");
                    Console.WriteLine();
                    Thread.Sleep(3000);

                    return user.role.ToString();
                }
                
            }
            return null;

        }
        public static void Login()
        {

        }
        public static void ValidateUser()
        {

        }
        public static void Logout()
        {

        }
    }
}
