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
        public bool BookEvent(Booking booking)
        {
            return BookingDbHandler.AddBooking(booking);
        }
        public List<Booking> GetAll()
        {
            
            return BookingDbHandler.ListOfBookings; 
        }

        public List<Booking> GetCustomerBookings(string username)
        {
            var Bookings = BookingDbHandler.ListOfBookings;
            List<Booking> customerBookings = null;
            if (Bookings != null)
            {
                customerBookings = Bookings.FindAll(b => b.CustomerUsername.ToLower().Equals(username.ToLower()));
            }
            return customerBookings;

        }
    }
}
