using Project.Models;
using Project.Controller;


namespace Project.Views
{
    public class Print
    {
        
        public static void PrintUsers<T>(List<T> users) where T : User
        {
            if (users != null)
            {
                foreach (T user in users)
                {
                    Console.WriteLine();

                    Console.WriteLine("Id: " + user.UserId);
                    Console.WriteLine("Name: " + user.Name);
                    Console.WriteLine("Username: " + user.Username);
                    Console.WriteLine("Email: " + user.Email);
                    Console.WriteLine();
                }
            }
            else
            {
                Error.NotFound("users");
            }

        }
    }
}
