using Project.Controller;


namespace Project.BusinessLayer
{
    public class Customer : User
    {
        public static Customer GetCustomer(string username)
        {
            List<Customer> customers = null;
            customers = DatabaseManager.DbObject.ReadCustomer();
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
            List<User> users = null;
            users= DatabaseManager.DbObject.ReadUsers();
            if (users != null)
            {
                List<User> customers = null;
                try
                {


                    customers = users.FindAll(u => u.role == Role.Customer);
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
                catch(Exception ex)
                {
                    Error.NotFound("customers");
                }
            }
            else
            {
                Error.NotFound("users");
            }
        }
    }
}
