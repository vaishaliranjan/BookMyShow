using Newtonsoft.Json;
using Project.Models;
using Project.Controller;


namespace Project.Database
{
    internal class EventDbHandler: DbHandler<Event>
    {
        private static EventDbHandler? eventDbInstance;
        private static string? _events_path;
        public List<Event> listOfEvents { get; set; }
        public static EventDbHandler EventDbInstance
        {
            get
            {
                if (eventDbInstance == null)
                {
                    eventDbInstance = new EventDbHandler();
                }
                return eventDbInstance;
            }
        }

        private EventDbHandler()
        {
            listOfEvents = new List<Event>();
            _events_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Events.json";

            try
            {
                string eventFileContent = File.ReadAllText(_events_path);
                listOfEvents = JsonConvert.DeserializeObject<List<Event>>(eventFileContent)!;
            }
            catch
            {
                Error.UnexpectedError();
            }
        }
        public bool AddEvent(Event newEvent)
        {
            if (AddEntry(newEvent, listOfEvents, _events_path))
                return true;
            return false;
        }

        public bool RemoveEvent(Event removeEvent)
        {
            Event eve = null;
            try
            {
                eve = listOfEvents.Single(e => e.Id == removeEvent.Id);
                if (eve != null) {
                    listOfEvents.Remove(eve);
                    UpdateEntry(_events_path, listOfEvents);
                    return true;
                }
                else
                {
                    Error.NotFound("event");
                    return false;
                }
            }
            catch
            {
                Error.UnexpectedError();
                return false;
            }
            
        }
        public void DecTicketToDB(Event bookedEvent, int numOfTickets)
        {

            
            foreach (var eve in listOfEvents)
            {
                if (eve.Id == bookedEvent.Id)
                {
                    eve.NumOfTicket-= numOfTickets;          
                }
            }
            
            UpdateEntry(_events_path,listOfEvents);

        }
    }
}
