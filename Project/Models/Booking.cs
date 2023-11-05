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
        public static int bookingIdInc = BookingDbHandler.BookingDbInstance.listOfBookings[-1].bookingId;

        public Booking(Event e, Customer c, int numofTickets, float price)
        {
            
            bookingId = ++bookingIdInc;
            bookedEvent = e;
            customer = c;
            numOfTickets = numofTickets;
            totalPrice = price;
        }
        

    }
}
