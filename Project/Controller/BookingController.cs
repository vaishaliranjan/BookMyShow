using Project.Database;
using Project.Models;


namespace Project.Controller
{
    public class BookingController
    {
        public void BookEvent(Booking booking)
        {
            BookingDbHandler.BookingDbInstance.AddBooking(booking);
            EventContoller .DecrementTicket(booking.bookedEvent, booking.numOfTickets);
        }
        public List<Booking> ViewBookings()
        {
            List<Booking> bookings = BookingDbHandler.BookingDbInstance.listOfBookings;
            return bookings;
        }
    }
}
