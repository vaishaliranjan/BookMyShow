using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer
{
    public class Organizer:User
    {


        public Organizer():base()
        { }
        //public Organizer(int id, string name, string username, string email, string password)
        //    : base(id, name, username, email, password)
        //{
        //    role = Role.Organizer;
        //}
        public static void ViewOrganizers()
        {
            var users = DatabaseManager.ReadUsers();
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
            var organizers = DatabaseManager.ReadOrganizer();
           
            Organizer organizer = organizers.Single(u => u.Username == username);
            return organizer;
        }
        public static Artist SelectArtist(int id)
        {
            var artists = DatabaseManager.ReadArtists();
            var choosenArtist = artists.Single(a => a.artistId == id);
           DatabaseManager.RemoveArtist(choosenArtist);
            return choosenArtist;
        }

        public static Venue SelectVenue(int id)
        {
            var venues = DatabaseManager.ReadVenues();
            var choosenVenue = venues.Single(a => a.venueId == id);
            DatabaseManager.RemoveVenue(choosenVenue);
            return choosenVenue;
        }
    }
}
