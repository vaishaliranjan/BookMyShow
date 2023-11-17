
using Project.Models;
using Project.Controller;
using Project.ControllerInterface;


namespace Project.Views
{
    public class BookingsUI
    {
        static int bookingId = Booking.BookingIdInc;
        public static void ShowBookings(List<Booking> bookings)
        {
            if (bookings != null)
            {
                Message.ViewBookings();
                foreach (var booking in bookings)
                {
                    Console.WriteLine();
                    Console.WriteLine("Customer Name: " + booking.Customer.Name);
                    Console.WriteLine("Event Name: " + booking.BookedEvent.Name);
                    Console.WriteLine("Artist: " + booking.BookedEvent.Artist.Name);
                    Console.WriteLine("Venue: " + booking.BookedEvent.Venue.Place);
                    Console.WriteLine("Date: " + booking.BookedEvent.Artist.Timing);
                    Console.WriteLine("Number of Tickets: " + booking.NumOfTickets);
                    Console.WriteLine("Price: " + booking.TotalPrice);
                    Console.WriteLine();

                }
                Console.ResetColor();
            }
            else
            {
                Error.NotFound("bookings");
            }
        }
        
        
        public static void BookTickets(Customer customer) 
        {
            IBookingController bookingController = new BookingController();
            IEventController eventController = new EventContoller();
            var choosenEvent = ChooseEvent();
            var numOfTickets = EnterNumberOfTickets(choosenEvent);
            double totalprice = numOfTickets * choosenEvent.Price;
            var booking = new Booking(++bookingId, choosenEvent, customer, numOfTickets, totalprice);
            bookingController.BookEvent(booking);
            eventController.DecrementTicket(choosenEvent, numOfTickets);
            Message.TicketsBooked();
        }

        static Event ChooseEvent()
        {
            IEventController eventContoller = new EventContoller();
            EventUI.ViewEvents(eventContoller);
            Event bookedEvent;
            int eventId;
            while (true)
            {
                Console.Write(Message.EnterEventId);
                eventId = InputValidation.IntegerValidation();
                bookedEvent = eventContoller.GetById(eventId);
                if (bookedEvent == null)
                {
                    Console.WriteLine(Message.DoesNotExist);
                    Console.WriteLine();
                    continue;
                }
                if (bookedEvent.NumOfTicket == 0)
                {
                    Console.WriteLine(Message.NoTicketsAvailable);
                    continue;
                }
                break;
            }
            return bookedEvent;
        }

        static int EnterNumberOfTickets(Event bookedEvent)
        {
            int numOfTickets;
            while (true)
            {
                Console.Write(Message.EnterNumOfTickets);
                numOfTickets = InputValidation.IntegerValidation();
                if (numOfTickets < 0 || bookedEvent.NumOfTicket < numOfTickets)
                {
                    Console.WriteLine(Message.NotValidTickets);
                    continue;
                }
                break;
            }
            return numOfTickets;
        }
    }
}
