using Project.Models;
using Project.Enum;
using Project.ControllerInterface;
using Project.ViewsInterface;

namespace Project.Views
{
    public class Registration:IRegistration
    {
        static int userIdInc = User.UserIdInc;
        public IAuthController AuthController { get; }

        public Registration(IAuthController authController)
        {
            AuthController = authController;
        }
        public void RegisterUser(Role roleInput)
        {
           
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            var name= HelperClass.EnterName();
            var username= RegisterEnterUsername();
            var email= HelperClass.EnterEmail();
            var password = HelperClass.RegisterEnterPassword();
            Console.ResetColor();
            var role = roleInput;
            bool result = false;
            if (role == Role.Admin)
            {
                var admin = new User(++userIdInc, name, username, email, password, Role.Admin);
                AuthController.Register(admin, Role.Admin);
                result = true;
            }

            else if (role == Role.Customer)
            {
                var customer = new User(++userIdInc, name, username, email, password, Role.Customer);
                AuthController.Register(customer, Role.Customer);
                result = true;
            }
            else if (role == Role.Organizer)
            {
                var organizer = new User(++userIdInc, name, username, email, password, Role.Organizer);
                AuthController.Register(organizer, Role.Organizer);
                result = true;
            }
            if (result)
            {
                Message.UserAdded(); 
            }
            else
            {
                Console.WriteLine(Message.ErrorOccurred);
                RegisterUser(roleInput);
            }
        }

        public string RegisterEnterUsername()
        {

            string username;
            while (true)
            {
                Console.Write(Message.EnterUsername);
                username = InputValidation.StringValidation();

                bool r = RegexValidation.IsValidUsername(username);
                if (r)
                {
                    bool res = AuthController.ValidateUser(username);
                    if (!res)
                    {
                        Console.WriteLine(Message.UserAlreadyExists);
                        continue;
                    }
                    break;
                }
                Console.WriteLine(Message.OnlyCharacters);
            }
            return username;

        }
    }
}
