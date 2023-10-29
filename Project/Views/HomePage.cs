using Newtonsoft.Json;
using Project.BusinessLayer;
using Project.UI;

namespace Project.UILayer
{
    public class HomePage
    {
        enum HomePageOptions
        {
            Login =1,
            Signup=2,
            Exit=3
        }
        static void Main(string[] args)
        {
            HomePageFunction();

        }
        public static void HomePageFunction()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("****************************************************************************************");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                               BOOKMYSHOW APPLICATION                                 *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("****************************************************************************************");
            
            Console.WriteLine("");
            Console.WriteLine("Select 1 or 2: ");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Signup (for customers only)");
            Console.WriteLine("3. Exit");
            Console.WriteLine();





            while (true)
            {
                Console.WriteLine("Choose any number: ");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case (int)HomePageOptions.Login:
                        Console.ResetColor();
                        Authenticate.LoginUI();
                        break;

                    case (int)HomePageOptions.Signup:
                        Console.ResetColor();
                        RegistrationUI.AddNewUserUI(Role.Customer);
                        break;

                    case (int)HomePageOptions.Exit:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        continue;
                }
                break;   
            }
        }
    }
}