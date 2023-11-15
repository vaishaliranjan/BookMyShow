using Project.Controller;
using Project.ControllerInterface;
using Project.Models;
using Project.UILayer;

namespace Project.Views
{
    public class VenueUI
    {
        public static void ViewVenues(IVenueController venueController)
        {
            var venues = venueController.GetAll();
            VenueUI.ShowVenues(venues);
        }
        static void ShowVenues(List<Venue> venues)
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
