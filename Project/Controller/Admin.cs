using Project.Controller;
using Project.Database;

namespace Project.BusinessLayer
{
    public class Admin: User
    {
        public static void ViewAdmins()
        {
            List<Admin> admins = AdminDbHandler.AdminDbInstance.listOfAdmins;
            if (admins != null)
            {
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
            else
            {
                Error.NotFound("admins");
            }
            
            
        }
    }
}
