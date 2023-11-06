using Project.Controller;
using Project.Database;
using System.Xml.Linq;

namespace Project.Models
{
    public class Admin : User
    {
        
        public Admin(int id,string name,string username, string email, string password, Role role)
        {
            this.UserId = id;
            this.Name = name;
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.role = role;
        }
    }
}
