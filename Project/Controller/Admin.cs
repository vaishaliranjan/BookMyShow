using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer
{
    public class Admin: User
    {
        public static void ViewAdmins()
        {
            var users = DatabaseManager.DbObject.ReadUsers();
            var admins = users.FindAll(u => u.role == Role.Admin);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                         ADMINS                            -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (var admin in admins)
            {

                Console.WriteLine();
                Console.WriteLine("Id: " + admin.UserId);
                Console.WriteLine("Name: " + admin.Name);
                Console.WriteLine("Username: " + admin.Username);
                Console.WriteLine("Email: " + admin.Email);
                Console.WriteLine();

            }
            Console.ResetColor();
        }
    }
}
