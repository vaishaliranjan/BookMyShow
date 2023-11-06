using Newtonsoft.Json;
using Project.Models;
using Project.Controller;


namespace Project.Database
{
    internal class OrganizerDbHandler: DbHandler<Organizer>
    {
        private static OrganizerDbHandler organizerDbInstance;
        private static string _user_path;
        public List<Organizer> listOfOrganizer { get; set; }
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
            listOfOrganizer = new List<Organizer>();
            //List<User> listOfUsers = UserDbHandler.UserDbInstance.listOfUsers;
            //listOfCustomers= listOfUsers.FindAll(u=> u.role == Role.Customer);

            _user_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Users.json";

            try
            {
                string userFileContent = File.ReadAllText(_user_path);
                List<Organizer> listOfUsers = JsonConvert.DeserializeObject<List<Organizer>>(userFileContent)!;
                listOfOrganizer = listOfUsers.FindAll(u => u.role == Role.Organizer);
            }
            catch
            {
                Error.UnexpectedError();
            }
        }
        public bool AddOrganizer(Organizer organizer)
        {
            if (AddEntry(organizer, listOfOrganizer, _user_path))
                return true;
            return false;
        }
    }
}
