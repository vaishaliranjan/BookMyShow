using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer
{
    public class Organizer:User
    {
        //public Organizer(int id, string name, string username, string email, string password)
        //    : base(id, name, username, email, password)
        //{
        //    role = Role.Organizer;
        //}
        public static void ViewOrganizers()
        {
            var users = DatabaseManager.ReadUsers();
            var organizers = users.FindAll(u => u.role == Role.Organizer);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                        ORGANIZERS                         -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
            
            foreach (var organizer in organizers)
            {

                Console.WriteLine();
                Console.WriteLine("Id: " + organizer.UserId);
                Console.WriteLine("Name: " + organizer.Name);
                Console.WriteLine("Username: " + organizer.Username);
                Console.WriteLine("Email: " + organizer.Email);
                Console.WriteLine();

            }
            Console.ResetColor();
        }
    }
}
