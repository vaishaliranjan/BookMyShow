using Project.Controller;
using Project.Database;

namespace Project.Models
{
    public class Customer : User
    {

        public Customer(int id, string name, string username, string email, string password, Role role)
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
