using Project.BusinessLayer;
using Project.Views;
using Project.Models;
using Project.Objects;
using Project.UILayer;

namespace Project.UI
{
    public static class RegistrationUI
    {
       
        public static void AddNewUserUI(Role roleInput, AdminObjects admin=null)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();
            string name;
            while (true)
            {
                Console.Write(Message.enterName);
                name = InputValidation.NullValidation();
                bool result=RegexValidation.isValidName(name);
                if(result)
                {
                    break;
                }
                Console.WriteLine(Message.onlyCharacters);
            }
            string username = null;
            while (true)
            {
                Console.Write(Message.enterUsername);
                username = InputValidation.NullValidation();

                bool result =RegexValidation.isValidName(username);
                if (result)
                {
                    break;
                }
                Console.WriteLine(Message.onlyCharacters);
            }
            string email = null;
            while (true)
            {
                Console.Write(Message.enterEmail);
                email = InputValidation.NullValidation();
                bool result =RegexValidation.isValidEmail(email);
                if (result)
                {
                    break;
                }
                Console.WriteLine(Message.entervalidEmail);
            }
            Console.Write(Message.enterPassword);
            string password = InputValidation.NullValidation();
           
            Console.ResetColor();
            var role = roleInput;
            User user = null ;
            
            if (role == Role.Admin)
            {
                user=AuthManager<Admin>.AuthObject.Register(name, username, email, password, Role.Admin);
                 
            }

            else if (role == Role.Customer)
            {
                 user= AuthManager<Customer>.AuthObject.Register(name, username, email, password, Role.Customer);
            }
            else if (role == Role.Organizer)
            {
                user = AuthManager<Organizer>.AuthObject.Register(name, username, email, password, Role.Organizer);
            }
            if (user !=null)
            {
                Message.UserAdded();
                
                if (role == Role.Admin)
                {
                    AdminUI.ADMINUI(admin);
                }
                else
                {
                    Authenticate.LoginUI();
                }
            }
            else
            {
                Message.UserExists();
                
            }
           
        }
    }
}
