using Project.BusinessLayer;


namespace Project.Controller
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
            this.bookingId = bookingIdInc;
            bookingIdInc++;
            this.bookedEvent = e;
            this.customer = c;
            this.numOfTickets = numofTickets;
            this.totalPrice = price;
        } 
        public static void BookEvent(Booking booking)
        {
            DatabaseManager.DbObject.AddBookingToDB(booking);
            Event.DecrementTicket(booking.bookedEvent, booking.numOfTickets);
            

        }

        public static void ViewBookings(string username, Role role)
        {
            List<Booking> bookings = null;
             bookings = DatabaseManager.DbObject.ReadBookings();
            if (bookings != null)
            {


                if (role == Role.Admin)
                {
                    showBookings(bookings);
                }
                else
                {
                    var customerBooking = bookings.FindAll(b => b.customer.Username == username);
                    showBookings(customerBooking);
                }
                void showBookings(List<Booking> bookings)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("-                                                           -");
                    Console.WriteLine("-                                                           -");
                    Console.WriteLine("-                         Bookings                          -");
                    Console.WriteLine("-                                                           -");
                    Console.WriteLine("-                                                           -");
                    Console.WriteLine("-------------------------------------------------------------");

                    foreach (var booking in bookings)
                    {

                        Console.WriteLine();
                        Console.WriteLine("Customer Name: " + booking.customer.Name);
                        Console.WriteLine("Event Name: " + booking.bookedEvent.Name);
                        Console.WriteLine("Artist: " + booking.bookedEvent.artist.Name);
                        Console.WriteLine("Venue: " + booking.bookedEvent.venue.Place);
                        Console.WriteLine("Date: " + booking.bookedEvent.artist.timing);
                        Console.WriteLine("Number of Tickets: " + booking.numOfTickets);
                        Console.WriteLine("Price: " + booking.totalPrice);
                        Console.WriteLine();

                    }
                    Console.ResetColor();
                }
            }
            else
            {
                Error.NotFound("bookins");
            }
        }

    }
}
