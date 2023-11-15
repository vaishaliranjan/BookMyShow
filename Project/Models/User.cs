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
        public Role Role;
        public string Password;

    }

}
