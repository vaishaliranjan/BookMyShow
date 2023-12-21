using Project.Models;
using Project.Controller;
using Project.Views;


namespace Project.Helpers
{
    public class Print
    {
        public static void ShowArtists(List<Models.Artist> artists)
        {
            if (artists != null)
            {
                Message.ViewArtists();
                foreach (var artist in artists)
                {
                    Console.WriteLine("Artist Id: " + artist.ArtistId);
                    Console.WriteLine("Artist Name: " + artist.Name);
                    Console.WriteLine("Artist Time: " + artist.Timing);
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
            else
            {
                Error.NotFound("artists");
            }

        }
        public static void PrintUsers<T>(List<T> users) where T : User
        {
            if (users != null)
            {
                foreach (T user in users)
                {
                    Console.WriteLine();

                    Console.WriteLine("Id: " + user.UserId);
                    Console.WriteLine("Name: " + user.Name);
                    Console.WriteLine("Username: " + user.Username);
                    Console.WriteLine("Email: " + user.Email);
                    Console.WriteLine();
                }
            }
            else
            {
                Error.NotFound("users");
            }

        }

        public static void ShowBookings(List<Booking> bookings)
        {
            if (bookings != null)
            {
                Message.ViewBookings();
                foreach (var booking in bookings)
                {
                    Console.WriteLine();
                    Console.WriteLine("Customer Name: " + booking.CustomerUsername);
                    Console.WriteLine("Event Name: " + booking.BookedEvent.Name);
                    Console.WriteLine("Artist: " + booking.BookedEvent.Artist.Name);
                    Console.WriteLine("Venue: " + booking.BookedEvent.Venue.Place);
                    Console.WriteLine("Date: " + booking.BookedEvent.Artist.Timing);
                    Console.WriteLine("Number of Tickets: " + booking.NumOfTickets);
                    Console.WriteLine("Price: " + booking.TotalPrice);
                    Console.WriteLine();

                }
                Console.ResetColor();
            }
            else
            {
                Error.NotFound("bookings");
            }
        }

        public static void ShowEvents(List<Event> events)
        {
            if (events != null)
            {
                foreach (Event e in events)
                {
                    Console.WriteLine();
                    Console.WriteLine("Event Id: " + e.Id);
                    Console.WriteLine("Name: " + e.Name);
                    Console.WriteLine("Timing: " + e.Artist.Timing);
                    Console.WriteLine("Artist: " + e.Artist.Name);
                    Console.WriteLine("Venue: " + e.Venue.Place);
                    Console.WriteLine("Number of tickets left: " + e.NumOfTicket);
                    Console.WriteLine("Price per ticket: " + e.Price);
                    Console.WriteLine();
                }
            }
            else
            {
                Error.NotFound("events");
            }
        }

        public static void ShowVenues(List<Venue> venues)
        {
            if (venues != null)
            {
                Message.ViewVenues();
                foreach (Venue venue in venues)
                {
                    Console.WriteLine("VenueID: " + venue.VenueId);
                    Console.WriteLine("Location: " + venue.Place);
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
            else
            {
                Error.NotFound("events");
            }
        }
    }
}
