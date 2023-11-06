using Project.Database;

namespace Project.Models
{
    public enum Role
    {
        Admin,
        Organizer,
        Customer
    }
    public class User
    {
        public static int userIdInc = UserDbHandler.UserDbInstance.listOfUsers[UserDbHandler.UserDbInstance.listOfUsers.Count - 1].UserId;
        public int UserId;
        public string Name;
        public string Username;
        public string Email;
        public Role role;
        public string Password;

    }

}
