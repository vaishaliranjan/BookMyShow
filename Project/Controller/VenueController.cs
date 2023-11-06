using Project.Database;
using Project.Models;


namespace Project.Controller
{
    public class VenueController
    {
        public bool AddNewVenue(Venue venue)
        {
            return VenueDbHandler.VenueDbInstance.AddVenue(venue);
        }
        public List<Venue> ViewVenues()
        {
            return VenueDbHandler.VenueDbInstance.listOfVenues;
            

        }

        public Venue SelectVenue(int id)
        {

            Venue choosenVenue = null;

            try
            {
                choosenVenue = VenueDbHandler.VenueDbInstance.listOfVenues.Single(a => a.venueId == id);
                VenueDbHandler.VenueDbInstance.RemoveVenue(choosenVenue);
                return choosenVenue;

            }
            catch
            {
                return choosenVenue;
            }


        }
    }
}
