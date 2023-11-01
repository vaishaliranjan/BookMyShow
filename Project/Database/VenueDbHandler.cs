using Newtonsoft.Json;
using Project.BusinessLayer;
using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database
{
    internal class VenueDbHandler: DbHandler
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
        public override bool AddEntry(object obj)
        {
            if (obj is Venue)
            {
                listOfVenues.Add((Venue)obj);
                if (UpdateEntry<Venue>(_venues_path, listOfVenues))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public bool RemoveVenue(Venue deleteVenue)
        {
            
            foreach (var venue in listOfVenues)
            {
                if (venue.venueId.Equals(deleteVenue.venueId))
                {
                    listOfVenues.Remove(venue);
                    UpdateEntry<Venue>(_venues_path, listOfVenues);
                    return true;
                }
            }
            return false;
        }
    }
}
