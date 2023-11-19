using Project.ControllerInterface;
using Project.Database;
using Project.DatabaseInterface;
using Project.Models;


namespace Project.Controller
{
    public class BookingController:IBookingController
    {
        public IBookingDbHandler BookingDbHandler { get; }

        public BookingController(IBookingDbHandler bookingDbHandler)
        {
            BookingDbHandler = bookingDbHandler;
        }
        public void BookEvent(Booking booking)
        {
            BookingDbHandler.AddBooking(booking);
        }
        public List<Booking> GetAll()
        {
            
            return BookingDbHandler.ListOfBookings; 
        }

        public List<Booking> GetCustomerBookings(string username)
        {
            var Bookings = BookingDbHandler.ListOfBookings;
            var customerBookings = Bookings.FindAll(b=> b.CustomerUsername.ToLower().Equals(username.ToLower()));
            return customerBookings;

        }
    }
}
