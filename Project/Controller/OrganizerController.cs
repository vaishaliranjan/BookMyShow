using Project.Database;
using Project.Models;


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
            try
            {
                organizer = OrganizerDbHandler.OrganizerDbInstance.listOfOrganizer.Single(u => u.Username == username);
                return organizer;
            }
            catch 
            { 
                return organizer;
            }
        }
        

        
    }
}
