﻿using Project.Database;

namespace Project.Models
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
        public static int eventIDInc = EventDbHandler.EventDbInstance.listOfEvents[EventDbHandler.EventDbInstance.listOfEvents.Count-1].Id;

    }
}
