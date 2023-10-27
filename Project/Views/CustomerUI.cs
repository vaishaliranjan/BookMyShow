using Project.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UILayer
{
    internal class CustomerUI
    {
        public static void CUSTOMERUI(string username)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                     CUSTOMER PAGE                         *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*************************************************************");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. View Events");
            Console.WriteLine("2. View Previous Bookings");
            Console.WriteLine("3. Log out");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter any one: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Event.ViewEvents(username, Role.Customer);

                Console.WriteLine();
                
                while (true)
                {
                    Console.Write("Press 0 to exit to main menu: ");
                    string ip= Console.ReadLine();
                    if (ip == "0")
                    {
                        CustomerUI.CUSTOMERUI(username);
                        break;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine();
                }
            }
        }
    }
}
