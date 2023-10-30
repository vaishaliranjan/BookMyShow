using Project.BusinessLayer;
using Project.Controller;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UILayer
{
    internal class CustomerUI
    {
        enum CustomerUIOptions
        {
            Exit = 0,
            ViewEvents = 1,
            ViewPreviousBookings = 2,
            LogOut = 3,
            BookTicket = 4
        }
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
            while (true)
            {
            customerLabel: Console.WriteLine("Choose any number: ");
                int input;
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("You can only enter a numerical value!");
                    goto customerLabel;
                }

                switch (input)
                {
                    case (int)CustomerUIOptions.ViewEvents:
                        Event.ViewEvents(username, Role.Customer);
                        Console.WriteLine();
                        Console.WriteLine("4. Book Ticket ");
                        Console.WriteLine("0. Exit ");
                        while (true)
                        {
                        viewEvents: Console.WriteLine("Choose any number: ");
                            int ip;
                            try
                            {
                                ip = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("You can only enter a numerical value!");
                                goto viewEvents;
                            }
                            switch (ip)
                            {
                                case (int)CustomerUIOptions.BookTicket:
                                    BookingsUI.BookTicketsUI(username, Role.Customer);
                                    break;

                                case (int)CustomerUIOptions.Exit:
                                    CustomerUI.CUSTOMERUI(username);
                                    break;

                                default:
                                    Console.WriteLine();
                                    Console.WriteLine("Invalid input!");
                                    Console.WriteLine();
                                    continue;
                            }
                            break;
                        }
                        break;

                    case (int)CustomerUIOptions.ViewPreviousBookings:
                        BookingsUI.ViewBookingsUI(username, Role.Customer);
                        break;

                    case (int)CustomerUIOptions.LogOut:
                        AuthManager<User>.AuthObject.Logout();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid input!!");
                        continue;
                }
                break;
            }
        }
    }
}
