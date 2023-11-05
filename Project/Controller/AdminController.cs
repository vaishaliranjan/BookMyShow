using Project.Database;
using Project.Models;

namespace Project.Controller
{
    public class AdminController
    {     
        public List<Admin> ViewAdmins()
        {   
            return AdminDbHandler.AdminDbInstance.listOfAdmins; 
        }           
       
    }
}
