using Project.BusinessLayer;
using Project.UILayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string name = null;
            while (true)
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine();
                if (String.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cant be empty..");
                    continue;
                }
                bool result= isValidName(name);
                if(result)
                {
                    break;
                }
                Console.WriteLine("Name can only include characters and should have minimum 5 characters");
            }
            string username = null;
            while (true)
            {
                Console.Write("Enter username: ");
                username = Console.ReadLine();
                if (String.IsNullOrEmpty(username))
                {
                    Console.WriteLine("username cant be empty ..");
                    continue;
                }
                bool result = isValidName(username);
                if (result)
                {
                    break;
                }
                Console.WriteLine("username can only include characters and should have minimum 5 characters");
            }
            string email = null;
            while (true)
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine();
                if (String.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Email cant be empty..");
                    continue;
                }
                bool result = isValidEmail(email);
                if (result)
                {
                    break;
                }
                Console.WriteLine("Enter a valid email address..");
            }
            string password = null;
            while (true)
            {
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
                if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Password cant be empty!");
                    continue;
                }
                break;
            }
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

        public static bool isValidEmail(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            bool res = Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
            return res;
        }
        public static bool isValidName(string name)
        {
            string regex = @"[a-z]{5}";
            bool res = Regex.IsMatch(name, regex, RegexOptions.IgnoreCase);
            return res;
        }
    }
}
