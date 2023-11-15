using Project.ControllerInterface;
using Project.Database;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class OrganizerController: IOrganizerController
    {
        public List<Organizer> GetAll()
        {

            return OrganizerDbHandler.OrganizerDbInstance.ListOfOrganizer;

        }
        public Organizer GetByUsername(string username)
        {
            Organizer organizer = null;
            try
            {
                organizer = OrganizerDbHandler.OrganizerDbInstance.ListOfOrganizer.Single(u => u.Username.ToLower().Equals(username.ToLower()));
                return organizer;
            }
            catch (Exception ex) 
            {
                HelperClass.LogException(ex, "More than one organizer with same username.");
                return organizer;
            }
        }
        

        
    }
}
