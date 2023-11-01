using Project.Controller;
using Project.Database;

namespace Project.BusinessLayer
{
    public class Customer : User
    {
        public static Customer GetCustomer(string username)
        {
            List<Customer> customers = CustomerDbHandler.CustomerDbInstance.listOfCustomers;
            if (customers != null)
            {
                Customer customer = null;
                try
                {
                    customer = customers.Single(u => u.Username == username);
                    return customer;
                }
                catch (Exception ex)
                {
                    return customer;
                }
            }
            else
            {
                Error.NotFound("customers");
                return null;
            }
        }

        public static void ViewCustomers()
        {
            List<Customer> customers = CustomerDbHandler.CustomerDbInstance.listOfCustomers;
            if (customers != null)
            {

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
                        Console.WriteLine("Id: " + customer.UserId);
                        Console.WriteLine("Name: " + customer.Name);
                        Console.WriteLine("Username: " + customer.Username);
                        Console.WriteLine("Email: " + customer.Email);
                        Console.WriteLine();

                    }
                    Console.ResetColor();
              
            }
            else
            {
                Error.NotFound("users");
            }
        }

       
    }
}
