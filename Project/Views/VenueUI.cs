using Project.Controller;
using Project.Models;
namespace Project.Views
{
    public class VenueUI
    {
        public static void ViewVenuesUI(VenueController venueController)
        {
            var venues = venueController.ViewVenues();
            Message.ViewVenues();
            foreach (Venue venue in venues)
            {
                Console.WriteLine("VenueID: " + venue.venueId);
                Console.WriteLine("Location: " + venue.Place);
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
