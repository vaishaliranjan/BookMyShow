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

        public static void ViewVenues()
        {
            List<Venue> venues = DatabaseManager.ReadVenues();
            foreach(Venue venue in venues)
            {
                Console.WriteLine("Location: "+venue.Place);
                Console.WriteLine();
            }

        }
    }
}
