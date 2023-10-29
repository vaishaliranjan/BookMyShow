using Project.BusinessLayer;
using Project.Controller;
using Project.UILayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views
{
    public class BookingsUI
    {
        enum BookingsOptions
        {
            AddNewBooking=1,
            Exit=0
        }
        public static void ViewBookingsUI(string username, Role role)
        {
            Console.WriteLine();

            Console.WriteLine("");
            Console.WriteLine("Bookings: ");
            Console.WriteLine();
            Booking.ViewBookings(username, role);

            Console.WriteLine();
            if (role == Role.Admin)
            {
                Console.WriteLine("1. Add new booking");
             
                Console.WriteLine("0. Back");
                Console.WriteLine();
                while (true)
                {

                    Console.Write("Enter any one: ");

                    int input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case (int)BookingsOptions.AddNewBooking:
                            BookTicketsUI(username, role);
                            break;

                        case (int)BookingsOptions.Exit:
                            Console.WriteLine();
                            AdminUI.ADMINUI(username);
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("Invalid input!!");
                            continue;
                    }

                    break;
                }

            }
            else
            {
                Console.WriteLine("0. Back");
                while (true)
                {

                    int input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                       
                        case (int)BookingsOptions.Exit:
                            Console.WriteLine();
                            CustomerUI.CUSTOMERUI(username);
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
        public static void BookTicketsUI(string username, Role role)
        {
            Console.WriteLine();
            Console.WriteLine("Enter Event Id: ");
            int eventId = Convert.ToInt32(Console.ReadLine());
            Event e = Event.GetEvent(eventId);
            Customer c;
            if (role == Role.Customer)
            {
                c = Customer.GetCustomer(username);
            }
            else
            {
                Console.WriteLine("Select one customer: ");
                Customer.ViewCustomers();
                Console.Write("Enter customer username: ");
                string uname = Console.ReadLine();
                c = Customer.GetCustomer(uname);
            }
            Console.WriteLine("Enter number of tickets required: ");
            int numOfTickets = Convert.ToInt32(Console.ReadLine());
            float totalprice = numOfTickets * e.Price;
            Booking b = new Booking(e, c, numOfTickets, totalprice);

            Booking.BookEvent(b);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-               Tickets Booked Successfully!                -");
            Console.WriteLine("-------------------------------------------------------------");
            Console.ResetColor();
            if (role == Role.Customer)
            {
                CustomerUI.CUSTOMERUI(username);
            }
            else
            {
                AdminUI.ADMINUI(username);
            }
        }
    }
}
