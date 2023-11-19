using Newtonsoft.Json;
using Project.Models;
using Project.Controller;
using Project.Views;
using Project.DatabaseInterface;

namespace Project.Database
{
    
    public class EventDbHandler: DbHandler<Event>, IEventDbHandler
    {
        private static EventDbHandler eventDbInstance;
        private static string _events_path;
        public List<Event> ListOfEvents { get; set; }
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
            ListOfEvents = new List<Event>();
            _events_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Project\Files\Events.json";

            try
            {
                string eventFileContent = File.ReadAllText(_events_path);
                ListOfEvents = JsonConvert.DeserializeObject<List<Event>>(eventFileContent)!;
            }
            catch(Exception ex)
            {
                Error.UnexpectedError();
                HelperClass.LogException(ex, "An error occurred while reading the json.");
            }
        }
        public bool AddEvent(Event newEvent)
        {
            if (AddEntry(newEvent, ListOfEvents, _events_path))
                return true;
            return false;
        }

        
        public bool DecTicketToDB(List<Event> list)
        {
            return UpdateEntry(_events_path,list);
        }
        public bool RemoveEvent(List<Event> events)
        {         
               return UpdateEntry(_events_path, ListOfEvents);
        }
    }
}
