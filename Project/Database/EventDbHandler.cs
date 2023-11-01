using Newtonsoft.Json;
using Project.BusinessLayer;
using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database
{
    internal class EventDbHandler: DbHandler
    {
        private static EventDbHandler eventDbInstance;
        private static string _events_path;
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
        public override bool AddEntry(object obj)
        {
            if (obj is Event)
            {
                listOfEvents.Add((Event)obj);
                if (UpdateEntry<Event>(_events_path, listOfEvents))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public void RemoveEvent(Event e)
        {
           
            foreach (var eve in listOfEvents)
            {
                if (eve.Id == e.Id)
                {
                    listOfEvents.Remove(eve);
                    UpdateEntry<Event>(_events_path, listOfEvents);
                }
            }
        }
        public void DecTicketToDB(Event events, int numOfTickets)
        {
        
            Event e = new Event();
            foreach (var eve in listOfEvents)
            {
                if (eve.Id == events.Id)
                {
                    e = eve;
                    e.NumOfTicket = e.NumOfTicket - numOfTickets;
                    listOfEvents.Remove(eve);
                    break;
                }
            }
            listOfEvents.Add(e);
            UpdateEntry<Event>(_events_path,listOfEvents);

        }
    }
}
