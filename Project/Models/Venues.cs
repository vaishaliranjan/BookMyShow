using Project.Database;

namespace Project.Models
{
    public class Venue
    {
        public int venueId;
        public string Place;
        public static int venueIDS = 106;
        public Venue(string Place)
        {
            this.Place = Place;
            venueId = venueIDS++;
        }
        
    }
}
