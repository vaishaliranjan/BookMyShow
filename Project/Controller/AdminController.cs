using Project.ControllerInterface;
using Project.DatabaseInterface;
using Project.Enum;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class AdminController: IAdminController
    {
        public IUserDbHandler UserDbHandler { get; }

        public AdminController(IUserDbHandler userDbHandler)
        {
            UserDbHandler = userDbHandler;
        }

        public List<User> GetAll()
        {
            var users = UserDbHandler.ListOfUsers;
            var Admins = users.FindAll(u => u.Role == Role.Admin);
            return Admins;
        }           
       
    }
}
