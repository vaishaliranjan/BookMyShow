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
        public Organizer organizer;
        public Artist artist;
        public Venue venue;
        public int NumOfTicket;
        public float Price;


        public static void ViewEvents(string username, Role r)
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
            if (r == Role.Admin)
            {
                ShowEvents(events);
            }
            else if (r == Role.Organizer){
                // var organizerEvents = events.FindAll(e => e.organizer.Username == username);
                List<Event> orgEvent = new List<Event>();

                if(orgEvent != null)
                {

                    foreach (var e in events)
                    {
                        if(e.organizer is Organizer)
                        {
                            if (e.organizer.Username == username)
                            {
                                orgEvent.Add(e);
                            }
                        }
                    }
                }

                ShowEvents(orgEvent);

            }
            void ShowEvents(List<Event> events)
            {
                foreach (Event e in events)
                {
                    Console.WriteLine();
                    Console.WriteLine("Name: " + e.Name);
                    Console.WriteLine("Timing: " + e.artist.timing);
                    Console.WriteLine("Artist: " + e.artist.Name);
                    Console.WriteLine("Venue: " + e.venue.Place);
                    if (e.organizer is Organizer)
                    {
                        Console.WriteLine("Organizer: " + e.organizer.Name);
                    }
                    else
                    {
                        Console.WriteLine("Error....");
                    }
                    Console.WriteLine("Number of tickets left: " + e.NumOfTicket);
                    Console.WriteLine("Price per ticket: " + e.Price);
                    Console.WriteLine();
                }
            }
            Console.ResetColor();
        }

        public static void AddEvent(Event newEvent)
        {
            DatabaseManager.AddEventToDB(newEvent);
        }
    }
}
