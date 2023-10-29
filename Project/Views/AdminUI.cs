using Project.BusinessLayer;
using Project.Controller;
using Project.UI;
using Project.Views;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UILayer
{
    internal class AdminUI
    {
        enum AdminUIOptions
        {
            ViewAdmins=1,
            ViewArtists=2,
            ViewVenues=3,
            ViewEvents=4,
            ViewOrganizers=5,
            ViewCustomers=6,
            ViewBookings=7,
            LogOut=8
        }
        public enum AdminFuncOptions
        {
            AddNew = 1,
            Cancel = 2,
            Exit = 0
        }
        public static void ADMINUI(string username)
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
            while (true)
            {
                Console.Write("Enter any one: ");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case (int)AdminUIOptions.ViewAdmins:
                        ViewAdminsUI(username);
                        break;

                    case (int)AdminUIOptions.ViewArtists:
                        ViewArtistUI(username);
                        break;

                    case (int)AdminUIOptions.ViewVenues:
                        ViewVenuesUI(username);
                        break;

                    case (int)AdminUIOptions.ViewEvents:
                        ViewEventsUI(username);
                        break;

                    case (int)AdminUIOptions.ViewOrganizers:
                        ViewOrganizersUI(username);
                        break;

                    case (int)AdminUIOptions.ViewCustomers:
                        ViewCustomersUI(username);
                        break;

                    case (int)AdminUIOptions.ViewBookings:
                        BookingsUI.ViewBookingsUI(username, Role.Admin);
                        break;

                    case (int)AdminUIOptions.LogOut:
                        AuthManager<User>.AuthObject.Logout();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine();
                        continue;
                }
                break;
            }   
        }

       

        //************************************************ VIEW Events UI ****************************************
        public static void ViewEventsUI(string username)
        {
            Console.WriteLine();

            Console.WriteLine("");
            Console.WriteLine("Events: ");
            Console.WriteLine();

            Event.ViewEvents(username, Role.Admin);
            Console.WriteLine();
            Console.WriteLine("1. Add new Event");
            Console.WriteLine("2. Cancel an Event");
            Console.WriteLine("0. Back");
            Console.WriteLine();
            while (true)
            {
               
                Console.Write("Enter any one: ");

                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case (int)AdminFuncOptions.AddNew:
                        EventUI.CreateEventUI(username, Role.Admin);
                        ADMINUI(username);
                        break;

                    case (int)AdminFuncOptions.Cancel:
                        EventUI.CancelEventUI(username, Role.Admin);
                        ADMINUI(username);
                        break;

                    case (int)AdminFuncOptions.Exit:
                        Console.WriteLine();
                        ADMINUI(username);
                        break;

                    default:
                        Console.WriteLine("Invalid Input!!");
                        Console.WriteLine();
                        continue;
                }
                break;
            }
            
        }


        //************************************************ VIEW ORGANIZERS UI ****************************************
        public static void ViewOrganizersUI( string username)
        {
            Console.WriteLine();

            Console.WriteLine("");
            Console.WriteLine("Organizers: ");
            Console.WriteLine();
            Organizer.ViewOrganizers();
            Console.WriteLine();

            Console.WriteLine("1. Add new Organizer");
            Console.WriteLine("0. Back");
            Console.WriteLine();
            while (true)
            {
                Console.Write("Enter any one: ");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case (int)AdminFuncOptions.AddNew:
                        RegistrationUI.AddNewUserUI(Role.Organizer);
                        break;

                    case (int)AdminFuncOptions.Exit:
                        Console.WriteLine();
                        ADMINUI(username);
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid input!!");
                        continue;
                }
                break;
            }
            

           
          
        }


        //************************************************ VIEW ARTIST UI ****************************************
        public static void ViewArtistUI(string username)
        {
            Console.WriteLine();

            Console.WriteLine("");
            Console.WriteLine("Artists: ");
            Console.WriteLine();
            Artist.ViewArtists();
            Console.WriteLine();

            Console.WriteLine("1. Add new Artist");
            Console.WriteLine("0. Back");
            Console.WriteLine();
            while (true)
            {
                Console.Write("Enter any one: ");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case (int)AdminFuncOptions.AddNew:
                        AddNewArtistUI(username);
                        break;

                    case (int)AdminFuncOptions.Exit:
                        Console.WriteLine();
                        ADMINUI(username);
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid input!!");
                        continue;
                }
                break;
            }

        }

        //************************************************* VIEW CUSTOMERS UI ************************************************
        public static void ViewCustomersUI(string username)
        {
            Console.WriteLine();
            
            Console.WriteLine("");
            Console.WriteLine("Customers: ");
            Customer.ViewCustomers();
            Console.WriteLine();
            Console.WriteLine("1. Add new Customer");
            Console.WriteLine("0. Back");
            Console.WriteLine();
            while (true)
            {
                Console.Write("Enter any one: ");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case (int)AdminFuncOptions.AddNew:
                        RegistrationUI.AddNewUserUI(Role.Customer);
                        break;

                    case (int)AdminFuncOptions.Exit:
                        Console.WriteLine();
                        ADMINUI(username);
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid input!!");
                        continue;
                }
                break;
            }
           
        }


        //************************************************* VIEW VENUES UI ************************************************
        public static void ViewVenuesUI(string username)
        {
            Console.WriteLine();

            Console.WriteLine("");
            Console.WriteLine("Venues: ");
            Console.WriteLine();
            Venue.ViewVenues();
            Console.WriteLine();
            Console.WriteLine("1. Add new Venue");
            Console.WriteLine("0. Back");
            Console.WriteLine();
            while (true)
            {
                Console.Write("Enter any one: ");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case (int)AdminFuncOptions.AddNew:
                        AddNewVenueUI(username);
                        break;

                    case (int)AdminFuncOptions.Exit:
                        Console.WriteLine();
                        ADMINUI(username);
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid input!!");
                        continue;
                }
                break;
            }
           
        }

        //************************************************* VIEW ADMINS UI ************************************************
        public static void  ViewAdminsUI(string username)
        {
            Console.WriteLine();

            Console.WriteLine("");
            Console.WriteLine("Admins: ");
            Console.WriteLine();
            Admin.ViewAdmins();
            Console.WriteLine();
            Console.WriteLine("1. Add new admin");
            Console.WriteLine("0. Back");
            Console.WriteLine();
            while (true)
            {
                Console.Write("Enter any one: ");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case (int)AdminFuncOptions.AddNew:
                        RegistrationUI.AddNewUserUI(Role.Admin);
                        break;

                    case (int)AdminFuncOptions.Exit:
                        Console.WriteLine();
                        ADMINUI(username);
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid input!!");
                        continue;
                }
                break;
            }
        }
        //ADD NEW ARTIST
        public static void AddNewArtistUI(string username)
        {
            Console.WriteLine("Enter Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter date and time (yyyy-MM-ddTHH:mm): ");
            string userInput = Console.ReadLine();

            DateTime dt = DateTime.ParseExact(userInput, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            var artist = new Artist(name, dt);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();
            Artist.AddNewArtist(artist);
            Console.WriteLine();
            Console.ResetColor();
            ADMINUI(username);
        }

        //ADD NEW VENUE
        public static void AddNewVenueUI(string username)
        {
            Console.WriteLine("Enter Place:");
            var place = Console.ReadLine();
            var venue = new Venue(place);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Venue.AddNewVenue(venue);
            Console.WriteLine();
            Console.ResetColor();
            ADMINUI(username);
        }

        
    }
}
