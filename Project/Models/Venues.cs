using Project.Database;

namespace Project.Models
{
    public class Venue
    {
        public int venueId;
        public string Place;
        public static int venueIdInc = VenueDbHandler.VenueDbInstance.listOfVenues[-1].venueId;
        public Venue(string Place)
        {
            this.Place = Place;
            venueId = ++venueIdInc;
        }
        
    }
}
