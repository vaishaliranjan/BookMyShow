using Project.Database;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controller
{
    public class OrganizerController
    {
        public List<Organizer> ViewOrganizers()
        {

            return OrganizerDbHandler.OrganizerDbInstance.listOfOrganizer;

        }
        public Organizer GetOrganizer(string username)
        {
            Organizer organizer = null;
            organizer = OrganizerDbHandler.OrganizerDbInstance.listOfOrganizer.Single(u => u.Username == username);
            if (organizer != null)
            {
                return organizer;
            }
            else
            {
                Error.NotFound("organizers");
                return organizer;
            }
        }
        

        
    }
}
