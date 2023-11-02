using Project.Database;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controller
{
    internal class OrganizerController
    {
        public static void ViewOrganizers()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                        ORGANIZERS                         -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (var organizer in OrganizerDbHandler.OrganizerDbInstance.listOfOrganizer)
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
            Organizer organizer = null;
            organizer = OrganizerDbHandler.OrganizerDbInstance.listOfOrganizer.Single(u => u.Username == username);
            if (organizer != null)
            {
                return organizer;
            }
            else
            {
                Error.NotFound("organizers");
                return organizer;
            }
        }
        public static Artist SelectArtist(int id)
        {

            Artist choosenArtist = null;
            try
            {
                choosenArtist = ArtistDbHandler.ArtistDbInstance.listOfArtists.Single(a => a.artistId == id);
                ArtistDbHandler.ArtistDbInstance.RemoveArtist(choosenArtist);
                return choosenArtist;
            }
            catch (Exception ex)
            {
                Error.NotFound("artist");
                return choosenArtist;
            }

        }

        public static Venue SelectVenue(int id)
        {

            Venue choosenVenue = null;

            try
            {
                choosenVenue = VenueDbHandler.VenueDbInstance.listOfVenues.Single(a => a.venueId == id);
                VenueDbHandler.VenueDbInstance.RemoveVenue(choosenVenue);
                return choosenVenue;

            }
            catch (Exception ex)
            {
                Error.NotFound("venue");
                return choosenVenue;
            }


        }
    }
}
