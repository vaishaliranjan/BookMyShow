using Project.Database;

namespace Project.Models
{
    public class Venue
    {
        public int venueId;
        public string Place;
        public static int venueIdInc = VenueDbHandler.VenueDbInstance.listOfVenues[VenueDbHandler.VenueDbInstance.listOfVenues.Count- 1].venueId;
        public Venue(int venueId, string Place)
        {
           
            this.Place = Place;
            this.venueId = venueId;
        }
        
    }
}
