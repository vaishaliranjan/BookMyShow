using Newtonsoft.Json;
using Project.Controller;
using Project.Models;
using Project.Views;

namespace Project.Database
{
    internal class VenueDbHandler: DbHandler<Venue>
    {
        private static VenueDbHandler venueDbInstance;
        private static string _venues_path;
        public List<Venue> ListOfVenues { get; set; }
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
            ListOfVenues = new List<Venue>();
            _venues_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Project\Files\Venues.json";

            try
            {
                string venuesFileContent = File.ReadAllText(_venues_path);
                ListOfVenues = JsonConvert.DeserializeObject<List<Venue>>(venuesFileContent)!;
            }
            catch(Exception ex)
            {
                Error.UnexpectedError();
                HelperClass.LogException(ex, "An error occurred while reading the json.");
            }
        }
        public bool AddVenue(Venue venue)
        {
            if (AddEntry(venue, ListOfVenues, _venues_path))
                return true;
            return false;
        }
        public bool RemoveVenue(List<Venue> listOfVenues)
        {
               return UpdateEntry(_venues_path, listOfVenues);         
        }
       
    }
}
