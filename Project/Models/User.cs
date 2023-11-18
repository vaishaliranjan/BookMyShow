using Project.Database;
using Project.Enum;

namespace Project.Models
{
    public class User
    {
        public static int UserIdInc = UserDbHandler.UserDbInstance.ListOfUsers[UserDbHandler.UserDbInstance.ListOfUsers.Count - 1].UserId;
        public int UserId;
        public string Name;
        public string Username;
        public string Email;
        public string Password;
        public Role Role;
        

        public User(int userId, string name, string username, string email,string password, Role role)
        {
            UserId = userId;
            Name = name;
            Username = username;
            Email = email;
            Password = password;
            Role = role;
        }
    }

}
