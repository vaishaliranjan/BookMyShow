using Newtonsoft.Json;
using Project.BusinessLayer;
using Project.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    //Singleton class-> DBManager
    public class DatabaseManager
    {
        private static DatabaseManager _dbObject;
        private DatabaseManager() { }

        public static DatabaseManager DbObject
        {
            get
            {
                if(_dbObject == null)
                {
                    _dbObject = new DatabaseManager();
                }
                return _dbObject;
            }
        }
        // PATHS
        private static string _user_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Users.json";
        private static string _artist_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Artists.json";
        private static string _venues_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Venues.json";
        private static string _events_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Events.json";

        private static string _bookings_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Bookings.json";

        
        public  List<User> ReadUsers()
        {
            var allUsers= File.ReadAllText(_user_path);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(allUsers);

            return users;
        }
        public  List<Organizer> ReadOrganizer()
        {
            var allUsers = File.ReadAllText(_user_path);
            List<Organizer> users = JsonConvert.DeserializeObject<List<Organizer>>(allUsers);
            var organizers = users.FindAll(o=> o.role == Role.Organizer);

            return organizers;
        }
        public  List<Customer> ReadCustomer()
        {
            var allUsers = File.ReadAllText(_user_path);
            List<Customer> users = JsonConvert.DeserializeObject<List<Customer>>(allUsers);
            var customers = users.FindAll(c => c.role == Role.Customer);

            return customers;
        }
        public  List<Booking> ReadBookings()
        {
            var allBookings = File.ReadAllText(_bookings_path);
            List<Booking> bookings = JsonConvert.DeserializeObject<List<Booking>>(allBookings);
            

            return bookings;
        }
        public  List<Artist> ReadArtists()
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
        public  List<Venue> ReadVenues()
        {
            var allVenue = File.ReadAllText(_venues_path);
           
            List<Venue> venues = JsonConvert.DeserializeObject<List<Venue>>(allVenue);

            return venues;
        }
        public  List<Event> ReadEvents()
        {
            var allEvents = File.ReadAllText(_events_path);

            List<Event> events = JsonConvert.DeserializeObject<List<Event>>(allEvents);

            return events;
        }
        public  void AddUser(User newUser)
        {
            List<User> allUsers = ReadUsers();
            allUsers.Add(newUser);

            var usersJSON = JsonConvert.SerializeObject(allUsers);
            File.WriteAllText(_user_path, usersJSON);
        }
        public void AddArtist(Artist newArtist)
        {
            
            var artistDetails = ReadArtists();
            artistDetails.Add(newArtist);

            var artistJSON = JsonConvert.SerializeObject(artistDetails);
            File.WriteAllText(_artist_path, artistJSON);
            Console.WriteLine();
            Console.WriteLine("Artist added successfully");
            Console.WriteLine();
        }
        public  void AddVenue(Venue venue)
        {

            var venueDetails = ReadVenues();
            venueDetails.Add(venue);

            var venueJSON = JsonConvert.SerializeObject(venueDetails);
            File.WriteAllText(_venues_path, venueJSON);
            Console.WriteLine();
            Console.WriteLine("Venue added successfully");
            Console.WriteLine();
        }
        public  void AddEventToDB(Event e)
        {
            var events = ReadEvents();
            events.Add(e);
            var eventsJSON = JsonConvert.SerializeObject(events);
            File.WriteAllText(_events_path, eventsJSON);
            

        }
        public  void AddBookingToDB(Booking b)
        {
            var bookings = ReadBookings();
            bookings.Add(b);
            var bookingsJSON = JsonConvert.SerializeObject(bookings);
            File.WriteAllText(_bookings_path, bookingsJSON);


        }
        public  void RemoveArtist(Artist deleteArtist)
        {
            var artistDetails = ReadArtists();
            foreach (var artist in artistDetails)
            {
                if (artist.artistId.Equals(deleteArtist.artistId))
                {
                    artistDetails.Remove(artist);
                    var artistJSON = JsonConvert.SerializeObject(artistDetails);
                    File.WriteAllText(_artist_path, artistJSON);
                    break;
                }
            }
        }
        public  void RemoveVenue(Venue deleteVenue)
        {
            var venueDetails = ReadVenues();
            foreach (var venue in venueDetails)
            {
                if (venue.venueId.Equals(deleteVenue.venueId))
                {
                    venueDetails.Remove(venue);
                    var venueJSON = JsonConvert.SerializeObject(venueDetails);
                    File.WriteAllText(_venues_path, venueJSON);
                    break;
                }
            }
        }
        public  void RemoveEvent(int id)
        {
            var events = ReadEvents();
            foreach (var e in events)
            {
                if (e.Id==id)
                {
                    events.Remove(e);
                    var eventsJSON = JsonConvert.SerializeObject(events);
                    File.WriteAllText(_events_path, eventsJSON);
                    break;
                }
            }
        }
        public void DecTicketToDB(int eventId, int numOfTickets)
        {
            var events = ReadEvents();
            Event e = new Event();
            foreach (var eve in events)
            {
                if (eve.Id == eventId)
                {
                    e = eve;
                    e.NumOfTicket = e.NumOfTicket - numOfTickets;
                    events.Remove(eve);
                    break;
                }
            }
            events.Add(e);
            var eventsJSON = JsonConvert.SerializeObject(events);
            File.WriteAllText(_events_path, eventsJSON);
        }
    }

   
}
