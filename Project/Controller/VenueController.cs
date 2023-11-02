using Project.Database;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controller
{
    internal class VenueController
    {
        public static void AddNewVenue(Venue venue)
        {
            VenueDbHandler.VenueDbInstance.RemoveVenue(venue);
        }
        public static void ViewVenues()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                            VENUES                         -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (Venue venue in VenueDbHandler.VenueDbInstance.listOfVenues)
            {
                Console.WriteLine("VenueID: " + venue.venueId);
                Console.WriteLine("Location: " + venue.Place);
                Console.WriteLine();
            }
            Console.ResetColor();

        }
    }
}
