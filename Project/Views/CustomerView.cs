using Project.ControllerInterface;
using Project.Enum;
using Project.Helpers;
using Project.Models;
using Project.ViewsInterface;

namespace Project.Views
{
    public class CustomerView:ICustomerView
    {
        public IBookingUI BookingUI { get; }
        public IEventUI EventUI { get; }    
        public IBookingController BookingController { get; }
        public IEventController EventController { get; }

        public CustomerView(IBookingUI bookingUI, IEventUI eventUI, IBookingController bookingController, IEventController eventController)
        {
            BookingUI = bookingUI;
            EventUI = eventUI;
            BookingController = bookingController;
            EventController = eventController;
        }


        public void ViewBookings(User customer)
        {
            var bookings = BookingController.GetCustomerBookings(customer.Username);
            Print.ShowBookings(bookings);
            while (true)
            {
                Message.PressToExit();
                BookingsOptions input;
                input = (BookingsOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case BookingsOptions.Exit:
                        break;

                    default:
                        Console.WriteLine(Message.InvalidInputMessage);
                        continue;
                }
                break;
            }
        }

        public void ViewEvents(User customer)
        {
            EventUI.ViewEvents();
            Message.CustomerViewEvents();
            while (true)
            {
                Console.Write(Message.ChooseNum);
                CustomerViewEventsOptions ip;
                ip = (CustomerViewEventsOptions)InputValidation.IntegerValidation();
                switch (ip)
                {
                    case CustomerViewEventsOptions.BookTicket:
                        BookingUI.BookTickets(customer.Username);
                        break;

                    case CustomerViewEventsOptions.Exit:
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
