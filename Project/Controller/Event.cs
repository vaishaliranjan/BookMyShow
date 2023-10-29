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
       
        public static void DecrementTicket(Event bookedEvent, int numOfTickets)
        {
            
            DatabaseManager.DbObject.DecTicketToDB(bookedEvent.Id, numOfTickets);

        }
        public static Event GetEvent(int  eventId)
        {
            var events = DatabaseManager.DbObject.ReadEvents();

            Event e = events.Single(e => e.Id == eventId);
            return e;
        }
        public static void ViewEvents(string username, Role r)
        {
            List<Event> events = DatabaseManager.DbObject.ReadEvents();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                            EVENTS                         -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
            if (r == Role.Admin || r== Role.Customer)
            {
                ShowEvents(events);
            }
            else if (r == Role.Organizer){
                var organizerEvents = events.FindAll(e => e.organizer.Username == username);
                ShowEvents(organizerEvents);

            }
            void ShowEvents(List<Event> events)
            {
                foreach (Event e in events)
                {
                    Console.WriteLine();
                    Console.WriteLine("Event Id: " + e.Id);
                    Console.WriteLine("Name: " + e.Name);
                    Console.WriteLine("Timing: " + e.artist.timing);
                    Console.WriteLine("Artist: " + e.artist.Name);
                    Console.WriteLine("Venue: " + e.venue.Place);
                    Console.WriteLine("Number of tickets left: " + e.NumOfTicket);
                    Console.WriteLine("Price per ticket: " + e.Price);
                    Console.WriteLine();
                }
            }
            Console.ResetColor();
        }
        public static void AddEvent(Event newEvent)
        {
            DatabaseManager.DbObject.AddEventToDB(newEvent);
        }
        public static void DeleteEvent(int deleteEventId)
        {
            DatabaseManager.DbObject.RemoveEvent(deleteEventId);
        }
    }
}
