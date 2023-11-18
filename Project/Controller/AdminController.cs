using Project.ControllerInterface;
using Project.Database;
using Project.Enum;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class AdminController: IAdminController
    {
        public List<User> GetAll()
        {
            var users = UserDbHandler.UserDbInstance.ListOfUsers;
            var Admins = users.FindAll(u => u.Role == Role.Admin);
            return Admins;
        }           
       
    }
}
