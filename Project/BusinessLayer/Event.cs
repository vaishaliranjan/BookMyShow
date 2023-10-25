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
        public DateTime Timing;
        public Artist artist;
        public Venue venue;
        public int NumOfTicket;
        public float Price;


        public static void ViewEvents()
        {
            List<Event> events = DatabaseManager.ReadEvents();
            foreach (Event e in events)
            {
                Console.WriteLine();
                Console.WriteLine("Name: "+ e.Name);
                Console.WriteLine("Timing: "+ e.Timing);
                Console.WriteLine("Artist: "+ e.artist);
                Console.WriteLine("Venue: "+ e.venue);
                Console.WriteLine("Number of tickets left: "+e.NumOfTicket);
                Console.WriteLine("Price per ticket: "+ e.Price);
                Console.WriteLine();
            }
        }
    }
}
