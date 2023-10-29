using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer
{
    public class Organizer:User
    {

        public static void ViewOrganizers()
        {
            var users = DatabaseManager.DbObject.ReadUsers();
            var organizers = users.FindAll(u => u.role == Role.Organizer);
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
        public static Organizer GetOrganizer(string username)
        {
            var organizers = DatabaseManager.DbObject.ReadOrganizer();
           
            Organizer organizer = organizers.Single(u => u.Username == username);
            return organizer;
        }
        public static Artist SelectArtist(int id)
        {
            var artists = DatabaseManager.DbObject.ReadArtists();
            var choosenArtist = artists.Single(a => a.artistId == id);
           DatabaseManager.DbObject.RemoveArtist(choosenArtist);
            return choosenArtist;
        }

        public static Venue SelectVenue(int id)
        {
            var venues = DatabaseManager.DbObject.ReadVenues();
            var choosenVenue = venues.Single(a => a.venueId == id);
            DatabaseManager.DbObject.RemoveVenue(choosenVenue);
            return choosenVenue;
        }
    }
}
