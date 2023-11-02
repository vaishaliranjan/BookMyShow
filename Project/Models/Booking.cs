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
        public static int bookingIdInc = 5;

        public Booking(Event e, Customer c, int numofTickets, float price)
        {
            bookingId = bookingIdInc;
            bookingIdInc++;
            bookedEvent = e;
            customer = c;
            numOfTickets = numofTickets;
            totalPrice = price;
        }
        

    }
}
