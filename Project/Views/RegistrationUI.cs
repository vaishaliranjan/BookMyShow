using Project.BusinessLayer;
using Project.Views;
using Project.Models;
using Project.Enum;
using Project.ControllerInterface;

namespace Project.UI
{
    public static class RegistrationUI
    {
        static int userIdInc = User.UserIdInc;
        
        public static void AddNewUser(Role roleInput)
        {
            IAuthController authController = AuthController.AuthObject;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            var name= EnterName();
            var username= EnterUsername();
            var email= EnterEmail();
            var password = EnterPassword();
            Console.ResetColor();
            var role = roleInput;
            bool result = false;
            if (role == Role.Admin)
            {
                var admin = new Admin(++userIdInc, name, username, email, password, Role.Admin);
                authController.Register(admin, Role.Admin);
                result = true;
            }

            else if (role == Role.Customer)
            {
                var customer = new Customer(++userIdInc, name, username, email, password, Role.Customer);
                authController.Register(customer, Role.Customer);
                result = true;
            }
            else if (role == Role.Organizer)
            {
                var organizer = new Organizer(++userIdInc, name, username, email, password, Role.Organizer);
                authController.Register(organizer, Role.Organizer);
                result = true;
            }
            if (result)
            {
                Message.UserAdded(); 
            }
            else
            {
                Console.WriteLine(Message.errorOccurred);
            }
        }


        static string EnterName()
        {
            Console.WriteLine();
            string name;
            while (true)
            {
                Console.Write(Message.enterName);
                name = InputValidation.StringValidation();
                bool ans = RegexValidation.IsValidName(name);
                if (ans)
                {
                    break;
                }
                Console.WriteLine(Message.onlyCharacters);
            }
            return name;
        }

        static string EnterUsername()
        {
            IAuthController authController = AuthController.AuthObject;
            string username;
            while (true)
            {
                Console.Write(Message.enterUsername);
                username = InputValidation.StringValidation();

                bool r = RegexValidation.IsValidName(username);
                if (r)
                {
                    bool res = authController.ValidateUser(username);
                    if (!res)
                    {
                        Console.WriteLine(Message.userExists);
                        continue;
                    }
                    break;
                }
                Console.WriteLine(Message.onlyCharacters);
            }
            return username;

        }

        static string EnterEmail()
        {
            string email;
            while (true)
            {
                Console.Write(Message.enterEmail);
                email = InputValidation.StringValidation();
                bool answer = RegexValidation.IsValidEmail(email);
                if (answer)
                {
                    break;
                }
                Console.WriteLine(Message.entervalidEmail);
            }
            return email;
        }

        static string EnterPassword()
        {
            Console.Write(Message.enterPassword);
            var password = InputValidation.StringValidation();
            return password;
        }
    }
}
