using Project.BusinessLayer;
using Project.UILayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UI
{
    public static class RegistrationUI
    {
        // ADD NEW USER
        public static void AddNewUserUI(Role roleInput)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Username: ");
            var username = Console.ReadLine();
            Console.Write("Enter Email: ");
            var email = Console.ReadLine();
            Console.Write("Enter Password: ");
            var password = Console.ReadLine();
            Console.ResetColor();
            var role = roleInput;
            bool flag = false;
            if (role == Role.Admin)
            {
                flag =AuthManager<Admin>.AuthObject.Register(name, username, email, password, Role.Admin);
            }

            else if (role == Role.Customer)
            {
                flag = AuthManager<Customer>.AuthObject.Register(name, username, email, password, Role.Customer);
            }
            else if (role == Role.Organizer)
            {
                flag = AuthManager<Organizer>.AuthObject.Register(name, username, email, password, Role.Organizer);
            }
            if (flag)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                 USER ADDED SUCCESSFULLY                   -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-------------------------------------------------------------");
                Console.ResetColor();
                if (role == Role.Admin)
                {
                    AdminUI.ADMINUI(username);
                }
                else
                {
                    Authenticate.LoginUI();
                }
            }
            else
            {
                RegistrationUI.AddNewUserUI(roleInput);
            }
        }
    }
}
