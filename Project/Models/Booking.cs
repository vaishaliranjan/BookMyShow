using Project.Database;

namespace Project.Models
{
    public class Booking
    {
        public int BookingId;
        public Event BookedEvent;
        public Customer Customer;
        public int NumOfTickets;
        public double TotalPrice;
        public static int BookingIdInc = BookingDbHandler.BookingDbInstance.ListOfBookings[BookingDbHandler.BookingDbInstance.ListOfBookings.Count-1].BookingId;

        public Booking(int bookingId,  Event e, Customer c, int numofTickets, double price)
        {  
            BookingId = bookingId;
            BookedEvent = e;
            Customer = c;
            NumOfTickets = numofTickets;
            TotalPrice = price;
        }
        

    }
}
