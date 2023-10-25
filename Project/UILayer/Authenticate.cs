using Project.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UILayer
{
    public static class Authenticate
    {
        public static void LoginUI()
        {
            while (true)
            {
                Role roleOfUser;
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                if (username == null)
                {
                    Console.WriteLine("Username can't be blank!");
                    continue;
                }
                else
                {
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
                    if(password == null)
                    {
                        Console.WriteLine("Password cant be blank!");
                    }
                    string userRole = AuthManager.Login(username, password);
                   if(userRole=="Admin")
                    {
                        AdminUI.ADMINUI();
                        break;
                        
                    }
                    else if (userRole == "Customer")
                    {
                        CustomerUI.CUSTOMERUI();
                        break;

                    }
                    else if (userRole == "Organizer")
                    {
                        OrganizerUI.ORGANIZERUI();
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Wrong credentials");
                        continue;
                    }
                }

            }
        }
}
}
