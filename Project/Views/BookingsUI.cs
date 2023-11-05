using Project.UILayer;
using Project.Enum;
using Project.Models;
using Project.Controller;

namespace Project.Views
{
    public class BookingsUI
    {
        public static void ShowBookings(List<Booking> bookings)
        {
            Message.ViewBookings();

            foreach (var booking in bookings)
            {
                Console.WriteLine();
                Console.WriteLine("Customer Name: " + booking.customer.Name);
                Console.WriteLine("Event Name: " + booking.bookedEvent.Name);
                Console.WriteLine("Artist: " + booking.bookedEvent.artist.Name);
                Console.WriteLine("Venue: " + booking.bookedEvent.venue.Place);
                Console.WriteLine("Date: " + booking.bookedEvent.artist.timing);
                Console.WriteLine("Number of Tickets: " + booking.numOfTickets);
                Console.WriteLine("Price: " + booking.totalPrice);
                Console.WriteLine();

            }
            Console.ResetColor();
        }
        public static void ViewBookingsUI(Role role,string username,BookingController bookingController ) 
        {
            var bookings = bookingController.ViewBookings();
            if (bookings != null)
            {
                if (role == Role.Admin)
                {
                    ShowBookings(bookings);
                    return;
                }
                else
                {
                    var customerBooking = bookings.FindAll(b => b.customer.Username == username);
                    ShowBookings(customerBooking);
                    return;
                }
            }
        }
        public static void BookTicketsUI(Customer customer) 
        {
            BookingController bookingController = new BookingController();
            EventContoller eventContoller = new EventContoller();
            EventUI.ViewEventsUI(Role.Customer);
            Event eventBooked;
            int eventId;
            bookTickets:  Console.Write(Message.eventId);
            eventId= InputValidation.IntegerValidation();
            eventBooked = EventContoller.GetEvent(eventId);
            if (eventBooked == null)
            {
                Console.WriteLine(Message.doesntExist);
                Console.WriteLine();
                goto bookTickets;
            }
            if(eventBooked.NumOfTicket == 0)
            {
                Console.WriteLine(Message.noTickets);
                goto bookTickets;
            }

        numofTickets: Console.Write(Message.numOfTickets);
            int numOfTickets = InputValidation.IntegerValidation();
                if(numOfTickets < 0 || eventBooked.NumOfTicket<numOfTickets)
                {
                    Console.WriteLine(Message.notValidTickets);
                    goto numofTickets;
                }
            float totalprice = numOfTickets * eventBooked.Price;
            Booking booking = new Booking(eventBooked, customer, numOfTickets, totalprice);
            bookingController.BookEvent(booking);
            Message.TicketsBooked();
            
        }
    }
}
