

namespace Project.BusinessLayer
{
    public enum Role
    {
        Admin,
        Organizer,
        Customer
    }
    public class User
    {
        public int UserId;
        public string Name;
        public string Username;
        public string Email;
        public Role role;
        public string Password;

    }
    
}
