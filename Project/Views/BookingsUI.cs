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

                viewBookingsAdmin: Console.WriteLine("Choose any number: ");
                    int input;
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("You can only enter a numerical value!");
                        goto viewBookingsAdmin;
                    }
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

                viewBookingsCustomer: Console.WriteLine("Choose any number: ");
                    int input;
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("You can only enter a numerical value!");
                        goto viewBookingsCustomer;
                    }
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
            Event.ViewEvents(username, role);
        bookTickets: Console.WriteLine("Enter Event Id: ");
            int eventId;
            try
            {
                eventId = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("You can only enter a numerical value!");
                goto bookTickets;
            }
            Event e = Event.GetEvent(eventId);
            if (e == null)
            {
                Console.WriteLine("Re enter event id!!!!!");
                Console.WriteLine();
                goto bookTickets;
            }
            Customer c;
            if (role == Role.Customer)
            {
                c = Customer.GetCustomer(username);
            }
            else
            {
               selectCustomer: Console.WriteLine("Select one customer: ");
                Customer.ViewCustomers();

                customerUsername: Console.Write("Enter customer username: ");
                string uname = null;
                try
                {
                    uname = Console.ReadLine()!;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("You can only enter string!");
                    goto customerUsername;
                }
                
                c = Customer.GetCustomer(uname);
                if (c == null)
                {
                    Console.WriteLine("Customer doesnt exist!");
                    goto selectCustomer;
                }
            }
           
        numofTickets: Console.WriteLine("Enter number of tickets required: ");
            int numOfTickets;
            try
            {
                numOfTickets = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("You can only enter a numerical value!");
                goto numofTickets;
            }
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
