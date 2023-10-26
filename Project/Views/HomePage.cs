using Newtonsoft.Json;
using Project.BusinessLayer;
using Project.UI;

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
                string input = Console.ReadLine();

                //DatabaseManager.ReadJSON();
                if (input == "1")
                {
                    Console.ResetColor();
                    Authenticate.LoginUI();
                    break;
                }
                else if(input == "2")
                {
                    Console.ResetColor();
                    RegistrationUI.AddNewUserUI(Role.Customer);
                    break;
                }
                else if(input == "3")
                {
                    Environment.Exit(0);
                }
                break;
            }
        }
    }
}