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
            List<Event> events = EventDbHandler.EventDbInstance.ListOfEvents;
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
            return EventDbHandler.EventDbInstance.ListOfEvents;
            
        }
        public List<Event> GetOrganizerEvents(string username)
        {
            List<Event> events = EventDbHandler.EventDbInstance.ListOfEvents;
            var organizerEvents = events.FindAll(e => e.Organizer.Username.ToLower().Equals(username.ToLower()));
            return organizerEvents;
        }
        public bool Add(Event newEvent)
        {
            return EventDbHandler.EventDbInstance.AddEvent(newEvent);
        }
        public bool Delete(int deleteEventId)
        {
            var events = EventDbHandler.EventDbInstance.ListOfEvents;
            foreach (Event e in events)
            {
                if (e.Id == deleteEventId)
                {
                    if (e.NumOfTicket == e.InitialTickets)
                    {
                        events.Remove(e);
                        return EventDbHandler.EventDbInstance.RemoveEvent(events);
                    }
                }
            }
            return false;
        }
    }
}
