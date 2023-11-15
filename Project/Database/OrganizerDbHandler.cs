using Newtonsoft.Json;
using Project.Models;
using Project.Controller;
using Project.Enum;
using Project.Views;

namespace Project.Database
{
    internal class OrganizerDbHandler: DbHandler<Organizer>
    {
        private static OrganizerDbHandler organizerDbInstance;
        private static string _user_path;
        public List<Organizer> ListOfOrganizer { get; set; }
        public static OrganizerDbHandler OrganizerDbInstance
        {
            get
            {
                if (organizerDbInstance == null)
                {
                    organizerDbInstance = new OrganizerDbHandler();
                }
                return organizerDbInstance;
            }
        }

        private OrganizerDbHandler()
        {
            ListOfOrganizer = new List<Organizer>();

            _user_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Project\Files\Users.json";

            try
            {
                string userFileContent = File.ReadAllText(_user_path);
                List<Organizer> listOfUsers = JsonConvert.DeserializeObject<List<Organizer>>(userFileContent)!;
                ListOfOrganizer = listOfUsers.FindAll(u => u.Role == Role.Organizer);
            }
            catch(Exception ex)
            {
                Error.UnexpectedError();
                HelperClass.LogException(ex, "An error occurred while reading the json.");
            }
        }
        public bool AddOrganizer(Organizer organizer)
        {
            if (AddEntry(organizer, ListOfOrganizer, _user_path))
                return true;
            return false;
        }
    }
}
