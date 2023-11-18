using Project.ControllerInterface;
using Project.Database;
using Project.Models;


namespace Project.Controller
{
    public class BookingController:IBookingController
    {

        public void BookEvent(Booking booking)
        {
            BookingDbHandler.BookingDbInstance.AddBooking(booking);
        }
        public List<Booking> GetAll()
        {
            
            return BookingDbHandler.BookingDbInstance.ListOfBookings; 
        }

        public List<Booking> GetCustomerBookings(string username)
        {
            var Bookings = BookingDbHandler.BookingDbInstance.ListOfBookings;
            var customerBookings = Bookings.FindAll(b=> b.CustomerUsername.ToLower().Equals(username.ToLower()));
            return customerBookings;

        }
    }
}
