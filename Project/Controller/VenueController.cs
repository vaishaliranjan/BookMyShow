using Project.ControllerInterface;
using Project.Database;
using Project.DatabaseInterface;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class VenueController: IVenueController
    {
        public IVenueDbHandler VenueDbHandler { get; }
        public VenueController(IVenueDbHandler venueDbHandler)
        {
            VenueDbHandler = venueDbHandler;
        }

        public bool Add(Venue venue)
        {
            return VenueDbHandler.AddVenue(venue);
        }
        public List<Venue> GetAll()
        {
            return VenueDbHandler.ListOfVenues; 
        }

        public Venue GetById(int id)
        {
            var Venues= VenueDbHandler.ListOfVenues;
            Venue choosenVenue = null;

            try
            {
                choosenVenue = Venues.Single(a => a.VenueId == id);
                RemoveVenue(choosenVenue);
                return choosenVenue;
            }
            catch(Exception ex) 
            {
                HelperClass.LogException(ex, "More than one venue with same id.");
                return choosenVenue;
            }


        }
        public bool RemoveVenue(Venue choosenVenue)
        {
            var Venues = VenueDbHandler.ListOfVenues;
            var venue = Venues.SingleOrDefault(v => v.VenueId == choosenVenue.VenueId);
            if (venue != null)
            {
                Venues.Remove(venue);
                return VenueDbHandler.RemoveVenue(Venues);
            }
            return false;
        }
    }
}
