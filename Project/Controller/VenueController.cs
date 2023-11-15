using Project.ControllerInterface;
using Project.Database;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class VenueController: IVenueController
    {
        public bool Add(Venue venue)
        {
            return VenueDbHandler.VenueDbInstance.AddVenue(venue);
        }
        public List<Venue> GetAll()
        {
            return VenueDbHandler.VenueDbInstance.ListOfVenues;
        }

        public Venue GetById(int id)
        {

            Venue choosenVenue = null;

            try
            {
                choosenVenue = VenueDbHandler.VenueDbInstance.ListOfVenues.Single(a => a.VenueId == id);
                RemoveVenue(choosenVenue);
                return choosenVenue;
            }
            catch(Exception ex) 
            {
                HelperClass.LogException(ex, "More than one venue with same id.");
                return choosenVenue;
            }


        }
        public static bool RemoveVenue(Venue choosenVenue)
        {
            var listOfVenues = VenueDbHandler.VenueDbInstance.ListOfVenues;
            var venue = listOfVenues.SingleOrDefault(v => v.VenueId == choosenVenue.VenueId);
            if (venue != null)
            {
                listOfVenues.Remove(venue);
                return VenueDbHandler.VenueDbInstance.RemoveVenue(listOfVenues);
            }
            return false;
        }
    }
}
