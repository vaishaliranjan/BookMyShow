using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DatabaseInterface
{
    public interface IEventDbHandler
    {
        List<Event> ListOfEvents { get; set; }
        bool AddEvent(Event newEvent);
        bool DecTicketToDB(List<Event> list);
        bool RemoveEvent(List<Event> events);
    }
}
