using Project.UI;
using Project.Enum;
using Project.Views;
using Project.Models;

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
            Console.Write(Message.ChooseNum);
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