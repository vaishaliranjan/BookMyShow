using Project.Database;

namespace Project.Models
{
    public class Booking
    {
        public int BookingId;
        public Event BookedEvent;
        public string CustomerUsername;
        public int NumOfTickets;
        public double TotalPrice;
        public static int BookingIdInc = BookingDbHandler.BookingDbInstance.ListOfBookings[BookingDbHandler.BookingDbInstance.ListOfBookings.Count-1].BookingId;

        public Booking(int bookingId,  Event e, string customerUsername, int numofTickets, double price)
        {  
            BookingId = bookingId;
            BookedEvent = e;
            CustomerUsername = customerUsername;
            NumOfTickets = numofTickets;
            TotalPrice = price;
        }
        

    }
}
