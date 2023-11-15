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
            List<Booking> bookings = BookingDbHandler.BookingDbInstance.ListOfBookings;
            return bookings;
        }

        public List<Booking> GetCustomerBookings(string username)
        {
            var bookings = BookingDbHandler.BookingDbInstance.ListOfBookings;
            var customerBookings = bookings.FindAll(b=> b.Customer.Username.ToLower().Equals(username.ToLower()));
            return customerBookings;

        }
    }
}
