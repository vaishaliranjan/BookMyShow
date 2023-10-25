using Newtonsoft.Json;
using Project.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public static class DatabaseManager
    {
        static List<User> users;
        static List<Artist> artists = new List<Artist>();

        private static string _user_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Users.json";
        private static string _artist_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Artists.json";
        private static string _venues_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Venues.json";
        private static string _events_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Events.json";

        public static List<User> ReadUsers()
        {
            var allUsers= File.ReadAllText(_user_path);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(allUsers);

            return users;
        }
        public static List<Artist> ReadArtists()
        {
            var allArtists = File.ReadAllText(_artist_path);
            var settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-ddTHH:mm",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            List<Artist> artists = JsonConvert.DeserializeObject<List<Artist>>(allArtists, settings);

            return artists;
        }

        public static List<Venue> ReadVenues()
        {
            var allVenue = File.ReadAllText(_venues_path);
           
            List<Venue> venues = JsonConvert.DeserializeObject<List<Venue>>(allVenue);

            return venues;
        }

        public static List<Event> ReadEvents()
        {
            var allEvents = File.ReadAllText(_events_path);

            List<Event> events = JsonConvert.DeserializeObject<List<Event>>(allEvents);

            return events;
        }
    }

   
}
