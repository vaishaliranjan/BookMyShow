using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer
{
    public class Event
    {
        public int Id;
        public string Name;
        
        public Artist artist;
        public Venue venue;
        public int NumOfTicket;
        public float Price;


        public static void ViewEvents()
        {
            List<Event> events = DatabaseManager.ReadEvents();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                            EVENTS                         -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
            
            foreach (Event e in events)
            {
                Console.WriteLine();
                Console.WriteLine("Name: "+ e.Name);
                Console.WriteLine("Timing: "+ e.artist.timing);
                Console.WriteLine("Artist: "+ e.artist.Name);
                Console.WriteLine("Venue: "+ e.venue.Place);
                Console.WriteLine("Number of tickets left: "+e.NumOfTicket);
                Console.WriteLine("Price per ticket: "+ e.Price);
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
