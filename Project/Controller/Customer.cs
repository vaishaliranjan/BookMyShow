using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer
{
    public class Customer : User
    {
        public static Customer GetCustomer(string username)
        {
            var customers = DatabaseManager.DbObject.ReadCustomer();
            Customer customer = customers.Single(u => u.Username == username);
            return customer;
        }

        public static void ViewCustomers()
        {
            var users= DatabaseManager.DbObject.ReadUsers();
            var customers = users.FindAll(u => u.role == Role.Customer);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                         CUSTOMERS                         -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
            
            foreach (var customer in customers)
            {

                Console.WriteLine();
                Console.WriteLine("Id: "+ customer.UserId);
                Console.WriteLine("Name: " + customer.Name);
                Console.WriteLine("Username: " + customer.Username);
                Console.WriteLine("Email: " + customer.Email);
                Console.WriteLine();

            }
            Console.ResetColor();
        }
    }
}
