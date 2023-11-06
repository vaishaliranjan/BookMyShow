using Project.Controller;
using Project.Database;

namespace Project.Models
{
    public class Booking
    {
        public int bookingId;
        public Event bookedEvent;
        public Customer customer;
        public int numOfTickets;
        public float totalPrice;
        public static int bookingIdInc = BookingDbHandler.BookingDbInstance.listOfBookings[BookingDbHandler.BookingDbInstance.listOfBookings.Count-1].bookingId;

        public Booking(int bookingId,  Event e, Customer c, int numofTickets, float price)
        {
            
            this.bookingId = bookingId;
            bookedEvent = e;
            customer = c;
            numOfTickets = numofTickets;
            totalPrice = price;
        }
        

    }
}
