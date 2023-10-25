using Newtonsoft.Json;
namespace Project.UILayer
{
    public class HomePage
    {
        static void Main(string[] args)
        {
            HomePageFunction();

        }
        static void HomePageFunction()
        {
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
            Console.WriteLine();





            while (true)
            {
                Console.WriteLine("Choose any number: ");
                string input = Console.ReadLine();

                //DatabaseManager.ReadJSON();
                if (input == "1")
                {
                    Authenticate.LoginUI();
                    break;
                }

            }


        }
    }
}