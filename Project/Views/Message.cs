using Project.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views
{
    internal class Message
    {
        public static string ChooseNum = "Choose any number: ";
        public static string enterUsername = "Enter username: ";
        public static string enterPassword = "Enter password: ";
        public static string enterName = "Enter Name:";
        public static void InvalidInput()
        {
            Console.WriteLine("You can only enter a numeric value!!");
            Console.Write("Re enter: ");
        }

        public static void OnlyString()
        {
            Console.WriteLine("Input can't be empty!");
            Console.Write("Re enter: ");
        }
        public static void LoginPage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                        LOGIN PAGE                         -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
        }
        public static void HomePage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("****************************************************************************************");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                               BOOKMYSHOW APPLICATION                                 *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("*                                                                                      *");
            Console.WriteLine("****************************************************************************************");

            Console.WriteLine("");
            Console.WriteLine("Select 1 or 2: ");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Signup (for customers only)");
            Console.WriteLine("3. Exit");
            Console.WriteLine();

        }
        public static void AdminPage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                        ADMIN PAGE                         *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*************************************************************");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. View admins");
            Console.WriteLine("2. View artists");
            Console.WriteLine("3. View venues");
            Console.WriteLine("4. View events");
            Console.WriteLine("5. View organizers");
            Console.WriteLine("6. View customers");
            Console.WriteLine("7. View bookings");
            Console.WriteLine("8. Log out");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void AdminViewEvents()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. Add new Event");
            Console.WriteLine("2. Cancel an Event");
            Console.WriteLine("0. Back");
            Console.WriteLine();
        }
        public static void AdminViewOrganizer()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add new Organizer");
            Console.WriteLine("0. Back");
            Console.WriteLine();
        }

        public static void AdminViewArtist()
        {
            Console.WriteLine("1. Add new Artist");
            Console.WriteLine("0. Back");
            Console.WriteLine();
        }
        public static void AdminViewCustomers()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add new Customer");
            Console.WriteLine("0. Back");
            Console.WriteLine();
        }
        
        public static void AdminViewVenues()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add new Venue");
            Console.WriteLine("0. Back");
            Console.WriteLine();
        }
        public static void AdminViewAdmins()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add new admin");
            Console.WriteLine("0. Back");
            Console.WriteLine();
        }

        public static void CustomerPage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                     CUSTOMER PAGE                         *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*************************************************************");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. View Events");
            Console.WriteLine("2. View Previous Bookings");
            Console.WriteLine("3. Log out");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void CustomerViewEvents()
        {
            Console.WriteLine();
            Console.WriteLine("1. Book Ticket ");
            Console.WriteLine("0. Exit ");
        }
        public static void OrganizerPage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                     ORGANIZERPAGE                         *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*************************************************************");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. Create an event");
            Console.WriteLine("2. View previously created events");
            Console.WriteLine("3. Cancel an event");
            Console.WriteLine("4. Logout");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

        }

        public static void OrganizerViewEvents()
        {
            Console.WriteLine();
            Console.Write("Press 0 to exit: ");
        }
    }
}
