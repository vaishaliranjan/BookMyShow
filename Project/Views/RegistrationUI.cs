using Project.BusinessLayer;
using Project.Models;
using Project.UILayer;
using Project.Views;

namespace Project.UI
{
    public static class RegistrationUI
    {
        // ADD NEW USER-
        public static void AddNewUserUI(Role roleInput)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();
            string name = null;
            while (true)
            {
                Console.Write("Enter Name: ");
                name = InputValidation.NullValidation();
                bool result=RegexValidation.isValidName(name);
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
                username = InputValidation.NullValidation();

                bool result =RegexValidation.isValidName(username);
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
                email = InputValidation.NullValidation();
                bool result =RegexValidation.isValidEmail(email);
                if (result)
                {
                    break;
                }
                Console.WriteLine("Enter a valid email address..");
            }
            Console.Write("Enter Password: ");
            string password = InputValidation.NullValidation();
           
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
