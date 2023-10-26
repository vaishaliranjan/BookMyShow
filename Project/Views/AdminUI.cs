﻿using Project.BusinessLayer;
using Project.UI;
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
        public static void ADMINUI()
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
            Console.WriteLine("7. Log out");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter any one: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                ViewAdminsUI();
            }
            else if (input == "2")
            {
                ViewArtistUI();
            }
            else if (input == "3")
            {
                ViewVenuesUI();
            }
            else if (input == "4")
            {
                ViewEventsUI();
            }
            else if (input == "5")
            {
                ViewOrganizersUI();
            }
            else if (input == "6")
            {
                ViewCustomersUI();
            }
            else if(input == "7")
            {
                AuthManager<User>.Logout();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input!");
                Console.WriteLine();
            }
        }

       

        //************************************************ VIEW Events UI ****************************************
        public static void ViewEventsUI()
        {
            Console.WriteLine();

            Console.WriteLine("");
            Console.WriteLine("Events: ");
            Console.WriteLine();
            Event.ViewEvents();
            Console.WriteLine();

            Console.WriteLine("1. Add new Event");
            Console.WriteLine("2. Cancel an Event");
            Console.WriteLine("0. Back");
            Console.WriteLine();
            Console.Write("Enter any one: ");

            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("Not implemmented yet");
            }
            else
            {
                Console.WriteLine();
                ADMINUI();
            }
        }


        //************************************************ VIEW ORGANIZERS UI ****************************************
        public static void ViewOrganizersUI()
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
            Console.Write("Enter any one: ");

            var input = Console.ReadLine();
            if (input == "1")
            {
                RegistrationUI.AddNewUserUI(Role.Organizer);
            }
            else
            {
                Console.WriteLine();
                ADMINUI();
            }
        }


        //************************************************ VIEW ARTIST UI ****************************************
        public static void ViewArtistUI()
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
            Console.Write("Enter any one: ");

            var input = Console.ReadLine();
            if (input == "1")
            {
                AddNewArtistUI();
            }
            else
            {
                Console.WriteLine();
                ADMINUI();
            }
        }

        //************************************************* VIEW CUSTOMERS UI ************************************************
        public static void ViewCustomersUI()
        {
            Console.WriteLine();
            
            Console.WriteLine("");
            Console.WriteLine("Customers: ");
            Customer.ViewCustomers();
            Console.WriteLine();
            Console.WriteLine("1. Add new Customer");
            Console.WriteLine("0. Back");
            Console.WriteLine();
            Console.Write("Enter any one: ");

            var input = Console.ReadLine();
            if(input == "1")
            {
                RegistrationUI.AddNewUserUI(Role.Customer);
            }
            else
            {
                Console.WriteLine();
                ADMINUI();
            }
        }


        //************************************************* VIEW VENUES UI ************************************************
        public static void ViewVenuesUI()
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
            Console.Write("Enter any one: ");

            var input = Console.ReadLine();
            if (input == "1")
            {
                AddNewVenueUI();
            }
            else
            {
                Console.WriteLine();
                ADMINUI();
            }
        }

        //************************************************* VIEW ADMINS UI ************************************************
        public static void  ViewAdminsUI()
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
            Console.Write("Enter any one: ");

            var input = Console.ReadLine();
            if (input == "1")
            {
               RegistrationUI.AddNewUserUI(Role.Admin);
            }
            else
            {
                Console.WriteLine();
                ADMINUI();
            }
        }
        //ADD NEW ARTIST
        public static void AddNewArtistUI()
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
            ADMINUI();
        }

        //ADD NEW VENUE
        public static void AddNewVenueUI()
        {
            Console.WriteLine("Enter Place:");
            var place = Console.ReadLine();
            var venue = new Venue(place);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Venue.AddNewVenue(venue);
            Console.WriteLine();
            Console.ResetColor();
            ADMINUI();
        }

        
    }
}