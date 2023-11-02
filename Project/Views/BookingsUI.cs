using Project.UILayer;
using Project.Enum;
using Project.Models;
using Project.Controller;

namespace Project.Views
{
    public class BookingsUI
    {
        
        public static void ViewBookingsUI(string username, Role role)
        {
            BookingController.ViewBookings(username, role);
            if (role == Role.Admin)
            {
                Console.WriteLine("1. Add new booking");
                Console.WriteLine("0. Back");
                Console.WriteLine();
                BookingsOptions input;
                Console.Write("Choose any number: ");
                while (true)
                {
                    input = (BookingsOptions)InputValidation.IntegerValidation();
                    switch (input)
                    {
                        case BookingsOptions.AddNewBooking:
                            BookTicketsUI(username, role);
                            break;

                        case BookingsOptions.Exit:
                            Console.WriteLine();
                            AdminUI.ADMINUI(username);
                            break;

                        default:
                            Message.InvalidInput();
                            continue;
                    }

                    break;
                }

            }
            else
            {
                Console.WriteLine("0. Back");
                Console.Write("Choose any number: ");
                while (true)
                {

                BookingsOptions input;
                input = (BookingsOptions)InputValidation.IntegerValidation();
                   
                    switch (input)
                    {
                       
                        case BookingsOptions.Exit:
                            Console.WriteLine();
                            CustomerUI.CUSTOMERUI(username);
                            break;
                          

                        default:
                            Message.InvalidInput();
                            continue;
                    }
                    break;
                }

            }
        }
        public static void BookTicketsUI(string username, Role role)
        {
            Console.WriteLine();
            EventContoller.ViewEvents(username, role);
            bookTickets:  Console.WriteLine("Enter Event Id: ");
            int eventId= InputValidation.IntegerValidation();
            Event e = EventContoller.GetEvent(eventId);
            if (e == null)
            {
                Console.WriteLine("Re enter event id!!!!!");
                Console.WriteLine();
                goto bookTickets;
            }
            if(e.NumOfTicket == 0)
            {
                Console.WriteLine("No Tickets Available!");
                goto bookTickets;
            }
            Customer c;
            if (role == Role.Customer)
            {
                c = CustomerController.GetCustomer(username);
            }
            else
            {
               selectCustomer: Console.WriteLine("Select one customer: ");
                CustomerController.ViewCustomers();
                Console.Write("Enter customer username: ");
                string uname = InputValidation.NullValidation();
                
                c = CustomerController.GetCustomer(uname);
                if (c == null)
                {
                    Console.WriteLine("Customer doesnt exist!");
                    goto selectCustomer;
                }
            }

        numofTickets: Console.WriteLine("Enter number of tickets required: ");
            int numOfTickets = InputValidation.IntegerValidation();
                if(numOfTickets < 0 || e.NumOfTicket<numOfTickets)
                {
                    Console.WriteLine("Tickets must be greater than 0 and less than num of tickets available.");
                    goto numofTickets;
                }
            float totalprice = numOfTickets * e.Price;
            Booking b = new Booking(e, c, numOfTickets, totalprice);
            BookingController.BookEvent(b);
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
