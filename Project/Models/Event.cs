using Project.Database;

namespace Project.Models
{
    public class Event
    {
        public int Id;
        public string Name;
        public string OrganizerUsername;
        public Artist Artist;
        public Venue Venue;
        public int InitialTickets;
        public int NumOfTicket;
        public double Price;
        public static int EventIDInc = EventDbHandler.EventDbInstance.ListOfEvents[EventDbHandler.EventDbInstance.ListOfEvents.Count-1].Id;
        public Event(int id, string name, string organizerUsername, Artist artist, Venue venue, int initialTickets, int numOfTickets, double price)
        {
            Id = id;
            Name = name;
            OrganizerUsername = organizerUsername;
            Artist = artist;
            Venue = venue;
            InitialTickets = initialTickets;
            NumOfTicket = numOfTickets;
            Price = price;
        }
    }
}
