using Project.Database;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controller
{
    internal class AdminController
    {

        public List<Admin> ViewAdmins()
        {
           
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                         ADMINS                            -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-------------------------------------------------------------");

                foreach (var admin in AdminDbHandler.AdminDbInstance.listOfAdmins)
                {

                    Console.WriteLine();
                    Console.WriteLine("Id: " + admin.UserId);
                    Console.WriteLine("Name: " + admin.Name);
                    Console.WriteLine("Username: " + admin.Username);
                    Console.WriteLine("Email: " + admin.Email);
                    Console.WriteLine();

                }
                Console.ResetColor();
            return AdminDbHandler.AdminDbInstance.listOfAdmins; 
        }
            

        
    }
}
