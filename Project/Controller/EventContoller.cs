using Project.ControllerInterface;
using Project.Database;
using Project.DatabaseInterface;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class EventContoller: IEventController
    {
        public IEventDbHandler EventDbHandler { get; }
        public EventContoller(IEventDbHandler eventDbHandler)
        {
            EventDbHandler = eventDbHandler;
        }
        public void DecrementTicket(Event bookedEvent, int numOfTickets)
        {
            var listOfEvents = EventDbHandler.ListOfEvents;
            foreach (var eve in listOfEvents)
            {
                if (eve.Id == bookedEvent.Id)
                {
                    eve.NumOfTicket -= numOfTickets;
                }
            }
            EventDbHandler.DecTicketToDB(listOfEvents);
        }
        public Event GetById(int eventId)
        {
            var Events = EventDbHandler.ListOfEvents;
            Event e = null;

            if (Events != null)
            {
                try
                {
                    e = Events.Single(e => e.Id == eventId);
                    return e;
                }
                catch (Exception ex)
                {
                    HelperClass.LogException(ex, "More than one event with same id.");
                    return e;
                }

            }
            else
            {             
                return e;
            }
        }
        public List<Event> GetAll()
        {
            
            var Events = EventDbHandler.ListOfEvents;
            if (Events != null)
            {
                return Events;
            }
            return null;
            
        }
        public List<Event> GetOrganizerEvents(string username)
        {
            var Events = EventDbHandler.ListOfEvents;
            List<Event> organizerEvents = null;
            if (Events != null)
            {
                organizerEvents = Events.FindAll(e => e.OrganizerUsername.Equals(username,StringComparison.InvariantCultureIgnoreCase));             
            }
            return organizerEvents;
        }
        public bool Add(Event newEvent)
        {
            return EventDbHandler.AddEvent(newEvent);
        }
        public bool Delete(int deleteEventId)
        {
            var Events = EventDbHandler.ListOfEvents;
            foreach (Event e in Events)
            {
                if (e.Id == deleteEventId)
                {
                    if (e.NumOfTicket == e.InitialTickets)
                    {
                        Events.Remove(e);
                        return EventDbHandler.RemoveEvent(Events);
                    }
                }
            }
            return false;
        }
    }
}
