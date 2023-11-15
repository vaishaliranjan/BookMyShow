
using Project.Enum;

namespace Project.Models
{
    public class Organizer : User
    {
        public Organizer(int id, string name, string username, string email, string password, Role role)
        {
            UserId = id;
            Name = name;
            Username = username;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
