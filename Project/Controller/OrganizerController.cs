using Project.ControllerInterface;
using Project.Database;
using Project.Enum;
using Project.Models;
using Project.Views;


namespace Project.Controller
{
    public class OrganizerController: IOrganizerController
    {
        public User GetByUsername(string username)
        {
            var users = UserDbHandler.UserDbInstance.ListOfUsers;
            var Organizers = users.FindAll(u => u.Role == Role.Organizer);
            if (Organizers != null)
            {
                User customer = null;
                try
                {
                    customer = Organizers.Single(u => u.Username.ToLower().Equals(username.ToLower()));
                    return customer;
                }
                catch (Exception ex)
                {
                    HelperClass.LogException(ex, "More than one customer with same username.");
                    return customer;
                }
            }
            else
            {
                return null;
            }
        }

        public List<User> GetAll()
        {
            var users = UserDbHandler.UserDbInstance.ListOfUsers;
            var Organizers = users.FindAll(u => u.Role == Role.Organizer);
            return Organizers;
        }
    }
}
