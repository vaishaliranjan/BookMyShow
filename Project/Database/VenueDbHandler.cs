using Newtonsoft.Json;
using Project.Controller;
using Project.Models;


namespace Project.Database
{
    internal class VenueDbHandler: DbHandler<Venue>
    {
        private static VenueDbHandler venueDbInstance;
        private static string _venues_path;
        public List<Venue> listOfVenues { get; set; }
        public static VenueDbHandler VenueDbInstance
        {
            get
            {
                if (venueDbInstance == null)
                {
                    venueDbInstance = new VenueDbHandler();
                }
                return venueDbInstance;
            }
        }
        private VenueDbHandler()
        {
            listOfVenues = new List<Venue>();
            _venues_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Venues.json";

            try
            {
                string venuesFileContent = File.ReadAllText(_venues_path);
                listOfVenues = JsonConvert.DeserializeObject<List<Venue>>(venuesFileContent)!;
            }
            catch
            {
                Error.UnexpectedError();
            }
        }
        public bool AddVenue(Venue venue)
        {
            if (AddEntry(venue, listOfVenues, _venues_path))
                return true;
            return false;
        }
        public bool RemoveVenue(Venue deleteVenue)
        {
            var venue= listOfVenues.Single(v=> v.venueId==deleteVenue.venueId);
            if(venue != null)
            {
                listOfVenues.Remove(venue);
                UpdateEntry(_venues_path, listOfVenues);
                return true;
            }
            return false;
        }
       
    }
}
