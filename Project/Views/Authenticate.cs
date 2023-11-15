using Project.BusinessLayer;
using Project.Models;
using Project.Views;
using Project.Objects;
using Project.Enum;
using Project.ControllerInterface;

namespace Project.UILayer
{
    public static class Authenticate
    {
        public static void Login()
        {
            while (true)
            {
                IAuthController authController = AuthController.AuthObject;
                string username = EnterUsername();
                string password = EnterPassword();
                var user = authController.Login(username, password);
                Console.ResetColor();
                if (user != null)
                {
                    if (user.Role==Role.Admin)
                    {
                        var newAdmin = new Admin(user.UserId, user.Name, user.Username, user.Email, user.Password, user.Role) ;
                        AdminUI.AdminPage(new AdminObjects(newAdmin));
                        break;
                    }
                    else if (user.Role==Role.Customer)
                    {
                        var newCustomer = new Customer(user.UserId, user.Name, user.Username, user.Email, user.Password, user.Role);
                        CustomerUI.CustomerPage(new CustomerObjects(newCustomer));
                        break;
                    }
                    else if (user.Role==Role.Organizer)
                    {
                        var newOrganizer = new Organizer(user.UserId, user.Name, user.Username, user.Email, user.Password, user.Role);
                        OrganizerUI.OrganizerPage(new OrganizerObjects(newOrganizer));
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(Message.WrongCredentials);
                    continue;
                }  
                
            }

            static string EnterUsername()
            {
                Console.Write(Message.enterUsername);
                var username = InputValidation.StringValidation();
                return username;
            }
            static string EnterPassword()
            {
                Console.Write(Message.enterPassword);
                var password = HelperClass.HideCharacter();
                return password;
            }
        }
        
    }
}

