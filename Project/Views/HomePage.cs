using Project.UI;
using Project.Enum;
using Project.Views;

namespace Project.UILayer
{
    public class HomePage
    {
        static void Main(string[] args)
        {
            try
            {
               
                HomePageFunction();
                
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Something went wrong!!");
                HelperClass.LogException(ex, "Something went wrong");
            }
            
        }
        public static void HomePageFunction()
        {
            Message.HomePage();
            
            while (true)
            {
                Console.Write(Message.ChooseNum);
                HomePageOptions input;
                input = (HomePageOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case HomePageOptions.Login:
                        Console.ResetColor();
                        Authenticate.Login();
                        break;

                    case HomePageOptions.Signup:
                        Console.ResetColor();
                        RegistrationUI.AddNewUser(Role.Customer);
                        Authenticate.Login();
                        break;

                    case HomePageOptions.Exit:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine(Message.invalidInput); 
                        continue;
                }
                break;   
            }
        }
    }
}