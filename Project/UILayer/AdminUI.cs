using Project.BusinessLayer;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UILayer
{
    internal class AdminUI
    {
        public static void ADMINUI()
        {
            Console.WriteLine("************************************Admin page*******************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. Add new admin");
            Console.WriteLine("2. View artists");
            Console.WriteLine("3. View venues");
            Console.WriteLine("4. View events");
            Console.WriteLine("5. View organizers");
            Console.WriteLine("6. View customers");

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter any one: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("Not implemented");
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
            else if (input == "6")
            {
                ViewCustomersUI();
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


        //************************************************ VIEW Events UI ****************************************
        public static void ViewOrganizersUI()
        {
            Console.WriteLine();

            Console.WriteLine("");
            Console.WriteLine("Organizers: ");
            Console.WriteLine();
            Artist.ViewArtists();
            Console.WriteLine();

            Console.WriteLine("1. Add new Organizer");
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
                Console.WriteLine("Not implemmented yet");
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
                Console.WriteLine("Not implemmented yet");
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
                Console.WriteLine("Not implemmented yet");
            }
            else
            {
                Console.WriteLine();
                ADMINUI();
            }
        }
    }
}
