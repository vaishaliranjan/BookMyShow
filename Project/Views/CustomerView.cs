using Project.Enum;
using Project.Models;
using Project.Objects;
using Project.UILayer;

namespace Project.Views
{
    public class CustomerView
    {
        public static void ViewBookings(CustomerObjects customer)
        {
            var bookings = customer.bookingController.GetCustomerBookings(customer.realCustomerObject.Username);
            BookingsUI.ShowBookings(bookings);
            while (true)
            {
                Message.PressToExit();
                BookingsOptions input;
                input = (BookingsOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case BookingsOptions.Exit:
                        Console.WriteLine();
                        CustomerUI.CustomerPage(customer);
                        break;

                    default:
                        Console.WriteLine(Message.InvalidInputMessage);
                        continue;
                }
                break;
            }
        }

        public static void ViewEvents(CustomerObjects customer)
        {
            EventUI.ViewEvents(customer.eventContoller);
            Message.CustomerViewEvents();
            while (true)
            {
                Console.Write(Message.ChooseNum);
                CustomerViewEventsOptions ip;
                ip = (CustomerViewEventsOptions)InputValidation.IntegerValidation();
                switch (ip)
                {
                    case CustomerViewEventsOptions.BookTicket:
                        BookingsUI.BookTickets(customer.realCustomerObject);
                        CustomerUI.CustomerPage(customer);
                        break;

                    case CustomerViewEventsOptions.Exit:
                        CustomerUI.CustomerPage(customer);
                        break;

                    default:
                        Console.WriteLine(Message.InvalidInputMessage);
                        continue;
                }
                break;
            }

        }
    }
}
