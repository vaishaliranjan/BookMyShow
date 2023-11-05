using Project.Database;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controller
{
    public class EventContoller
    {
        public static void DecrementTicket(Event bookedEvent, int numOfTickets)
        {
            EventDbHandler.EventDbInstance.DecTicketToDB(bookedEvent, numOfTickets);


        }
        public static Event GetEvent(int eventId)
        {
            List<Event> events = EventDbHandler.EventDbInstance.listOfEvents;
            Event e = null;

            if (events != null)
            {
                try
                {
                    e = events.Single(e => e.Id == eventId);
                    return e;
                }
                catch (Exception ex)
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
        public List<Event> ViewEvents()
        {
            List<Event> events = EventDbHandler.EventDbInstance.listOfEvents;
            return events;
        }
        public bool AddEvent(Event newEvent)
        {
            return EventDbHandler.EventDbInstance.AddEvent(newEvent);
        }
        public bool DeleteEvent(int deleteEventId)
        {
            var events = EventDbHandler.EventDbInstance.listOfEvents;
            foreach (Event e in events)
            {
                if (e.Id == deleteEventId)
                {
                    if (e.NumOfTicket == e.initialTickets)
                    {
                        EventDbHandler.EventDbInstance.RemoveEvent(e);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
