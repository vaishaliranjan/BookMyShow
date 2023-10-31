using Project.Controller;


namespace Project.BusinessLayer
{
    public class Event
    {
        public int Id;
        public string Name;
        public Organizer organizer;
        public Artist artist;
        public Venue venue;
        public int initialTickets;
        public int NumOfTicket;
        public float Price;
       
        public static void DecrementTicket(Event bookedEvent, int numOfTickets)
        {
            
            DatabaseManager.DbObject.DecTicketToDB(bookedEvent.Id, numOfTickets);

        }
        public static Event GetEvent(int  eventId)
        {
            List<Event> events = null;
            Event e = null;
            events = DatabaseManager.DbObject.ReadEvents();
            if (events != null)
            {
                try
                {
                    e = events.Single(e => e.Id == eventId);
                    return e;
                }
                catch(Exception ex)
                {
                    Error.NotFound("event");
                    return e;
                }
               
            }
            else
            {
                Error.NotFound("events");
                return e;
            }
        }
        public static void ViewEvents(string username, Role r)
        {
            List<Event> events = null;
             events = DatabaseManager.DbObject.ReadEvents();
            if (events != null)
            {


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                            EVENTS                         -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-------------------------------------------------------------");
                if (r == Role.Admin || r == Role.Customer)
                {
                    ShowEvents(events);
                }
                else if (r == Role.Organizer)
                {
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
            else
            {
                Error.NotFound("events");
            }
        }
        public static void AddEvent(Event newEvent)
        {
            DatabaseManager.DbObject.AddEventToDB(newEvent);
        }
        public static bool DeleteEvent(int deleteEventId)
        {
            var events = DatabaseManager.DbObject.ReadEvents();
            foreach (Event e in events)
            {
                if(e.Id== deleteEventId)
                {
                    if (e.NumOfTicket == e.initialTickets)
                    {
                        DatabaseManager.DbObject.RemoveEvent(e);
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}
