//using Newtonsoft.Json;
//using Project.BusinessLayer;
//using Project.Controller;


//namespace Project
//{
//    //Singleton class-> DBManager
//    public sealed class DatabaseManager
//    {
//        private static DatabaseManager _dbObject;
//        private DatabaseManager() { }

//        public static DatabaseManager DbObject
//        {
//            get
//            {
//                if (_dbObject == null)
//                {
//                    _dbObject = new DatabaseManager();
//                }
//                return _dbObject;
//            }
//        }
//        // PATHS
//        private static string _user_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Users.json";
//        private static string _artist_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Artists.json";
//        private static string _venues_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Venues.json";
//        private static string _events_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Events.json";

//        private static string _bookings_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Bookings.json";

//        private string _errorMsg = "An unexpected error occurred while reading the DB!";

//        public List<User> ReadUsers()
//        {

//            List<User> users = null;
//            try
//            {
//                var allUsers = File.ReadAllText(_user_path);
//                users = JsonConvert.DeserializeObject<List<User>>(allUsers)!;

//                return users;
//            }
//            catch (Exception ex)
//            {
//                Error.Invalid(_errorMsg);
//                return users;
//            }

//        }
//        public List<Organizer> ReadOrganizer()
//        {
//            List<Organizer> organizers = null;
//            try
//            {
//                var allUsers = File.ReadAllText(_user_path);
//                List<Organizer> users = JsonConvert.DeserializeObject<List<Organizer>>(allUsers)!;
//                organizers = users.FindAll(o => o.role == Role.Organizer);

//                return organizers;
//            }
//            catch (Exception)
//            {
//                Error.Invalid(_errorMsg);
//                return organizers;
//            }
//        }
//        public List<Customer> ReadCustomer()
//        {
//            List<Customer> customers = null;
//            try
//            {
//                var allUsers = File.ReadAllText(_user_path);
//                List<Customer> users = JsonConvert.DeserializeObject<List<Customer>>(allUsers);
//                customers = users.FindAll(c => c.role == Role.Customer);

//                return customers;
//            }
//            catch (Exception)
//            {
//                Error.Invalid(_errorMsg);
//                return customers;
//            }

//        }
//        public List<Booking> ReadBookings()
//        {
//            List<Booking> bookings = null;
//            try
//            {
//                var allBookings = File.ReadAllText(_bookings_path);
//                bookings = JsonConvert.DeserializeObject<List<Booking>>(allBookings)!;
//                return bookings;
//            }
//            catch (Exception)
//            {
//                Error.Invalid(_errorMsg);
//                return bookings;
//            }
//        }
//        public List<Artist> ReadArtists()
//        {
//            List<Artist> artists = null;
//            try
//            {
//                var allArtists = File.ReadAllText(_artist_path);
//                var settings = new JsonSerializerSettings
//                {
//                    DateFormatString = "yyyy-MM-ddTHH:mm",
//                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
//                };
//                artists = JsonConvert.DeserializeObject<List<Artist>>(allArtists, settings)!;

//                return artists;
//            }
//            catch (Exception)
//            {
//                Error.Invalid(_errorMsg);
//                return artists;
//            }
//        }
//        public List<Venue> ReadVenues()
//        {
//            List<Venue> venues = null;
//            try
//            {
//                var allVenue = File.ReadAllText(_venues_path);
//                venues = JsonConvert.DeserializeObject<List<Venue>>(allVenue)!;
//                return venues;
//            }
//            catch (Exception)
//            {
//                Error.Invalid(_errorMsg);
//                return venues;
//            }

//        }
//        public List<Event> ReadEvents()
//        {
//            List<Event> events = null;
//            try
//            {
//                var allEvents = File.ReadAllText(_events_path);
//                events = JsonConvert.DeserializeObject<List<Event>>(allEvents);
//                return events;
//            }
//            catch (Exception)
//            {
//                Error.Invalid(_errorMsg);
//                return events;
//            }
//        }
//        public void AddUser(User newUser)
//        {
//            List<User> allUsers = ReadUsers();
//            allUsers.Add(newUser);
//            try
//            {
//                var usersJSON = JsonConvert.SerializeObject(allUsers);
//                File.WriteAllText(_user_path, usersJSON);
//            }
//            catch (Exception)
//            {
//                Error.Invalid(_errorMsg);
//            }

//        }
//        public void AddArtist(Artist newArtist)
//        {

//            var artistDetails = ReadArtists();
//            artistDetails.Add(newArtist);
//            try
//            {
//                var artistJSON = JsonConvert.SerializeObject(artistDetails);
//                File.WriteAllText(_artist_path, artistJSON);
//                Console.WriteLine();
//                Console.WriteLine("Artist added successfully");
//                Console.WriteLine();
//            }
//            catch (Exception)
//            {
//                Error.Invalid(_errorMsg);
//            }
//        }
//        public void AddVenue(Venue venue)
//        {

//            var venueDetails = ReadVenues();
//            venueDetails.Add(venue);
//            try
//            {
//                var venueJSON = JsonConvert.SerializeObject(venueDetails);
//                File.WriteAllText(_venues_path, venueJSON);
//                Console.WriteLine();
//                Console.WriteLine("Venue added successfully");
//                Console.WriteLine();
//            }
//            catch (Exception)
//            {
//                Error.Invalid(_errorMsg);
//            }
//        }
//        public void AddEventToDB(Event e)
//        {
//            var events = ReadEvents();
//            events.Add(e);
//            try
//            {
//                var eventsJSON = JsonConvert.SerializeObject(events);
//                File.WriteAllText(_events_path, eventsJSON);
//            }
//            catch (Exception)
//            {
//                Error.Invalid(_errorMsg);
//            }

//        }
//        public void AddBookingToDB(Booking b)
//        {
//            var bookings = ReadBookings();
//            bookings.Add(b);
//            try
//            {
//                var bookingsJSON = JsonConvert.SerializeObject(bookings);
//                File.WriteAllText(_bookings_path, bookingsJSON);
//            }
//            catch (Exception)
//            {
//                Error.Invalid(_errorMsg);
//            }
//        }
//        public void RemoveArtist(Artist deleteArtist)
//        {
//            var artistDetails = ReadArtists();
//            foreach (var artist in artistDetails)
//            {
//                if (artist.artistId.Equals(deleteArtist.artistId))
//                {
//                    artistDetails.Remove(artist);
//                    try
//                    {
//                        var artistJSON = JsonConvert.SerializeObject(artistDetails);
//                        File.WriteAllText(_artist_path, artistJSON);
//                        break;
//                    }
//                    catch (Exception)
//                    {
//                        Error.Invalid(_errorMsg);
//                    }
//                }
//            }
//        }
//        public void RemoveVenue(Venue deleteVenue)
//        {
//            var venueDetails = ReadVenues();
//            foreach (var venue in venueDetails)
//            {
//                if (venue.venueId.Equals(deleteVenue.venueId))
//                {
//                    venueDetails.Remove(venue);
//                    try
//                    {
//                        var venueJSON = JsonConvert.SerializeObject(venueDetails);
//                        File.WriteAllText(_venues_path, venueJSON);
//                        break;
//                    }
//                    catch (Exception)
//                    {
//                        Error.Invalid(_errorMsg);
//                    }
//                }
//            }
//        }
//        public void RemoveEvent(Event e)
//        {
//            var events = ReadEvents();
//            foreach (var eve in events)
//            {
//                if (eve.Id == e.Id)
//                {
//                    events.Remove(eve);
//                    try
//                    {
//                        var eventsJSON = JsonConvert.SerializeObject(events);
//                        File.WriteAllText(_events_path, eventsJSON);
//                        break;
//                    }
//                    catch (Exception)
//                    {
//                        Error.Invalid(_errorMsg);
//                    }
//                }
//            }
//        }
//        public void DecTicketToDB(int eventId, int numOfTickets)
//        {
//            var events = ReadEvents();
//            Event e = new Event();
//            foreach (var eve in events)
//            {
//                if (eve.Id == eventId)
//                {
//                    e = eve;
//                    e.NumOfTicket = e.NumOfTicket - numOfTickets;
//                    events.Remove(eve);
//                    break;
//                }
//            }
//            events.Add(e);
//            try
//            {
//                var eventsJSON = JsonConvert.SerializeObject(events);
//                File.WriteAllText(_events_path, eventsJSON);
//            }
//            catch (Exception)
//            {
//                Error.Invalid(_errorMsg);
//            }

//        }
//    }


//}
