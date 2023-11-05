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
        public static string enterEmail = "Enter email: ";
        public static string enterPassword = "Enter password: ";
        public static string enterName = "Enter Name:";
        public static string selectOrganizer = "Select an organizer: ";
        public static string doesntExist = "Doesnt exist!";
        public static string selectCustomer = "Select a customer: ";
        public static string venueAdded = "Venue added successfully";
        public static string artistAdded = "Artist added successfully";
        public static string errorOccurred = "An error occurred";
        public static string enterPlace = "Enter place name: ";
        public static string wrongCredentials = "Wrong credentials";
        public static string eventId = "Enter Event Id: ";
        public static string numOfTickets = "Enter number of tickets: ";
        public static string noTickets = "No Tickets Available!";
        public static string notValidTickets="Tickets must be greater than 0 and less than num of tickets available.";
        public static string selectArtist = "Select Artist: ";
        public static string artistId = "Enter Artist Id: ";
        public static string selectVenue = "Select Venue: ";
        public static string venueId = "Enter Venue Id: ";
        public static string eventName = "Enter name of the event: ";
        public static string pricePerTicket = "Enter price per ticket: ";
        public static string onlyCharacters = "It can only include characters";
        public static string entervalidEmail = "Enter a valid email address..";
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

        public static void AdminViewEventsOptions()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. Add new Event");
            Console.WriteLine("2. Cancel an Event");
            Console.WriteLine("0. Back");
            Console.WriteLine();
        }
        public static void AdminViewBookingsOptions()
        {
            Console.WriteLine("1. Add new booking");
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
            Console.WriteLine("*                     ORGANIZER PAGE                        *");
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

        public static void PressToExit()
        {
            Console.WriteLine();
            Console.Write("Press 0 to exit: ");
        }
        
        public static void ViewEvents()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                            EVENTS                         -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
        }

        public static void ViewCustomers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                         CUSTOMERS                         -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
        }

        public static void ViewOrganizers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                         ORGANIZERS                        -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
        }
        public static void ViewAdmins()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                           ADMINS                          -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
        }

        public static void ViewArtists()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                           ARTISTS                         -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
        }
        public static void ViewBookings()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                         Bookings                          -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
        }
        public static void ViewVenues()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                            VENUES                         -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
        }
        public static void TicketsBooked()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-               Tickets Booked Successfully!                -");
            Console.WriteLine("-------------------------------------------------------------");
            Console.ResetColor();
        }
        public static void EventAdded()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                  Event Added Successfully!                -");
            Console.WriteLine("-------------------------------------------------------------");
            Console.ResetColor();
        }
        public static void EventDeleted()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                Event Deleted Successfully!                -");
            Console.WriteLine("-------------------------------------------------------------");
            Console.ResetColor();
        }
        public static void CantCancelEvent()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                 Tickets already booked!                   -");
            Console.WriteLine("-                 Event can't be deleted!                   -");
            Console.WriteLine("-------------------------------------------------------------");
            Console.ResetColor();
        }
        public static void UserAdded()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                 USER ADDED SUCCESSFULLY                   -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-                                                           -");
            Console.WriteLine("-------------------------------------------------------------");
            Console.ResetColor();
        }
        public static void UserExists()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                  USER ALREADY EXISTS!                     -");
            Console.WriteLine("-------------------------------------------------------------");
            Console.ResetColor();
        }
    }
}
