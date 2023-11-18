using Project.ControllerInterface;
using Project.Database;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class EventContoller: IEventController
    {
        
        public void DecrementTicket(Event bookedEvent, int numOfTickets)
        {
            var listOfEvents = EventDbHandler.EventDbInstance.ListOfEvents;
            foreach (var eve in listOfEvents)
            {
                if (eve.Id == bookedEvent.Id)
                {
                    eve.NumOfTicket -= numOfTickets;
                }
            }
            EventDbHandler.EventDbInstance.DecTicketToDB(listOfEvents);
        }
        public Event GetById(int eventId)
        {
            var Events = EventDbHandler.EventDbInstance.ListOfEvents;
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
            var Events = EventDbHandler.EventDbInstance.ListOfEvents;
            return Events;
            
        }
        public List<Event> GetOrganizerEvents(string username)
        {
            var Events = EventDbHandler.EventDbInstance.ListOfEvents; 
            var organizerEvents = Events.FindAll(e => e.OrganizerUsername.ToLower().Equals(username.ToLower()));
            return organizerEvents;
        }
        public bool Add(Event newEvent)
        {
            return EventDbHandler.EventDbInstance.AddEvent(newEvent);
        }
        public bool Delete(int deleteEventId)
        {
            var Events = EventDbHandler.EventDbInstance.ListOfEvents;
            foreach (Event e in Events)
            {
                if (e.Id == deleteEventId)
                {
                    if (e.NumOfTicket == e.InitialTickets)
                    {
                        Events.Remove(e);
                        return EventDbHandler.EventDbInstance.RemoveEvent(Events);
                    }
                }
            }
            return false;
        }
    }
}
