
using Project.BusinessLayer;
using Project.UI;
using Project.Enum;
using Project.Views;

namespace Project.UILayer
{
    public class HomePage
    {
        
        static void Main(string[] args)
        {
            HomePageFunction();

        }
        public static void HomePageFunction()
        {
            Message.HomePage();
            Console.Write("Choose any number: ");
            while (true)
            {
            HomePageOptions input;
                input = (HomePageOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case HomePageOptions.Login:
                        Console.ResetColor();
                        Authenticate.LoginUI();
                        break;

                    case HomePageOptions.Signup:
                        Console.ResetColor();
                        RegistrationUI.AddNewUserUI(Role.Customer);
                        break;

                    case HomePageOptions.Exit:
                        Environment.Exit(0);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;   
            }
        }
    }
}