using Project.Enum;
using Project.ControllerInterface;
using Project.ViewsInterface;

namespace Project.Views
{
    public class Authenticate:IAuthenticate
    {
        public IAuthController AuthController { get; }
        public IAdminUI AdminUI { get; }
        public ICustomerUI CustomerUI { get; }
        public IOrganizerUI OrganizerUI { get; }
        public Authenticate(IAuthController authController, IAdminUI adminUI, ICustomerUI customerUI, IOrganizerUI organizerUI)
        {
            AuthController = authController;
            AdminUI = adminUI;
            CustomerUI = customerUI;
            OrganizerUI = organizerUI;
        }

        public void Login()
        {
            while (true)
            {
                string username = HelperClass.EnterUsername();
                string password = HelperClass.EnterPassword();
                var user = AuthController.Login(username, password);
                Console.ResetColor();
                if (user != null)
                {
                    if (user.Role==Role.Admin)
                    {
                        AdminUI.AdminPage(user);
                        break;
                    }
                    else if (user.Role==Role.Customer)
                    {
                        CustomerUI.CustomerPage(user);
                        break;
                    }
                    else if (user.Role==Role.Organizer)
                    {
                        OrganizerUI.OrganizerPage(user);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(Message.WrongCredentials);
                    continue;
                }                 
            }           
        }       
    }
}