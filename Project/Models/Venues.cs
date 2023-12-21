using Project.Database;

namespace Project.Models
{
    public class Venue
    {
        public int VenueId;
        public string Place;
        public static int VenueIdInc = VenueDbHandler.VenueDbInstance.ListOfVenues[VenueDbHandler.VenueDbInstance.ListOfVenues.Count- 1].VenueId;
        public Venue(int venueId, string place)
        {
            Place = place;
            VenueId = venueId;
        }
        
    }
}
