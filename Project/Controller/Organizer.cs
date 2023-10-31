using Project.Controller;


namespace Project.BusinessLayer
{
    public class Organizer:User
    {

        public static void ViewOrganizers()
        {
            List<User> users = null;
            List<User> organizers = null;
             users = DatabaseManager.DbObject.ReadUsers();
            if (users != null)
            {
                try
                {
                    organizers = users.FindAll(u => u.role == Role.Organizer);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("-                                                           -");
                    Console.WriteLine("-                                                           -");
                    Console.WriteLine("-                        ORGANIZERS                         -");
                    Console.WriteLine("-                                                           -");
                    Console.WriteLine("-                                                           -");
                    Console.WriteLine("-------------------------------------------------------------");

                    foreach (var organizer in organizers)
                    {

                        Console.WriteLine();
                        Console.WriteLine("Id: " + organizer.UserId);
                        Console.WriteLine("Name: " + organizer.Name);
                        Console.WriteLine("Username: " + organizer.Username);
                        Console.WriteLine("Email: " + organizer.Email);
                        Console.WriteLine();

                    }
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Error.NotFound("organizers");
                }
            }
            else
            {
                Error.NotFound("users");
            }
        }
        public static Organizer GetOrganizer(string username)
        {
            List<Organizer> organizers = null;
            Organizer organizer = null;
            organizers = DatabaseManager.DbObject.ReadOrganizer();
            if (organizers != null)
            {
                try
                {
                    organizer = organizers.Single(u => u.Username == username);
                    return organizer;
                }
                catch(Exception ex)
                {
                    Error.NotFound("organizer");
                    return organizer;
                }
            }
            else
            {
                Error.NotFound("organizers");
                return organizer;
            }
        }
        public static Artist SelectArtist(int id)
        {
            List<Artist> artists = null;
            artists = DatabaseManager.DbObject.ReadArtists();
            Artist choosenArtist = null;
            if (artists != null)
            {
                
                try
                {
                    choosenArtist = artists.Single(a => a.artistId == id);
                    DatabaseManager.DbObject.RemoveArtist(choosenArtist);
                    return choosenArtist;
                }
                catch(Exception ex)
                {
                    Error.NotFound("artist");
                    return choosenArtist;
                }
                
            }
            else
            {
                Error.NotFound("artists");
                return choosenArtist;
            }

        }

        public static Venue SelectVenue(int id)
        {
            List<Venue> venues = null;
            Venue choosenVenue = null;
            venues = DatabaseManager.DbObject.ReadVenues();
            if (venues != null)
            {
                try
                {
                    choosenVenue = venues.Single(a => a.venueId == id);
                    DatabaseManager.DbObject.RemoveVenue(choosenVenue);
                    return choosenVenue;
                }
                catch (Exception ex)
                {
                    Error.NotFound("venue");
                    return choosenVenue;
                }
                
            }
            else
            {
                Error.NotFound("venues");
                return choosenVenue;
            }
        }
    }
}
