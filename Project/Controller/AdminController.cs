using Project.ControllerInterface;
using Project.Database;
using Project.Models;

namespace Project.Controller
{
    public class AdminController: IAdminController
    {     
        public List<Admin> GetAll()
        {      
            return AdminDbHandler.AdminDbInstance.ListOfAdmins;
        }           
       
    }
}
