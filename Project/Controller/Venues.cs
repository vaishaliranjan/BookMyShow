using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer
{
    public class Venue
    {
        public int venueId;
        public string Place;
        public static int venueIDS = 106;
        public Venue(string Place)
        {
            this.Place = Place;
            this.venueId = venueIDS++;
        }
        public static void AddNewVenue(Venue venue)
        {
            DatabaseManager.AddVenue(venue);
        }
        public static void ViewVenues()
        {
            List<Venue> venues = DatabaseManager.ReadVenues();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                            VENUES                         -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
            
            foreach (Venue venue in venues)
            {
                Console.WriteLine("VenueID: " + venue.venueId);
                Console.WriteLine("Location: "+venue.Place);
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
