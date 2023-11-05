using Project.Controller;
using Project.Enum;
using Project.Helper;
using Project.Models;
using Project.Objects;
using Project.UI;
using Project.UILayer;
using System.Data;


namespace Project.Views
{
    internal class AdminOptionsUI
    {
        public static void ViewBookingsUI(AdminObjects admin)
        {
            BookingsUI.ViewBookingsUI(Role.Admin, admin.realAdminObject.Username, admin.bookingController);
            Message.AdminViewBookingsOptions();
            BookingsOptions input;
            Console.Write(Message.ChooseNum);
            while (true)
            {
                input = (BookingsOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case BookingsOptions.AddNewBooking:
                        AddNewBooking(admin);
                        AdminUI.ADMINUI(admin);
                        break;

                    case BookingsOptions.Exit:
                        Console.WriteLine();
                        AdminUI.ADMINUI(admin);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }

                break;
            }

        }
        public static void ViewEventsUI(AdminObjects admin)
        {
            
            EventUI.ViewEventsUI(Role.Admin);
            Message.AdminViewEventsOptions();
            AdminFuncOptions ip;
            Console.Write(Message.ChooseNum);
            while (true)
            {
                ip = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (ip)
                {
                    case AdminFuncOptions.AddNew:
                        AddNewEvent(admin);
                        AdminUI.ADMINUI(admin);
                        break;

                    case AdminFuncOptions.Cancel:
                        CancelEvent(admin);
                        AdminUI.ADMINUI(admin);
                        break;

                    case AdminFuncOptions.Exit:
                        AdminUI.ADMINUI(admin);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }
        }
         static void CancelEvent(AdminObjects admin)
        {
            EventUI.ViewEventsUI(Role.Admin);
            EventUI.CancelEventUI();
        }
         static void AddNewEvent(AdminObjects admin)
        {
            Organizer organizerOfEvent = null;
            admin.organizationController.ViewOrganizers();
        selectOrganizer: Console.WriteLine(Message.selectOrganizer);
            
            Console.Write(Message.enterUsername);
            string uname = InputValidation.NullValidation();
            organizerOfEvent = admin.organizationController.GetOrganizer(uname);
            if (organizerOfEvent == null)
            {
                Console.WriteLine(Message.doesntExist);
                goto selectOrganizer;
            }
            EventUI.CreateEventUI(Role.Organizer, organizerOfEvent);
            

        }

        static void AddNewBooking(AdminObjects admin)
        {
            Customer customer = null;
            admin.customerController.ViewCustomers();
        selectCustomer: Console.WriteLine(Message.selectCustomer);
            
            Console.Write(Message.enterUsername);
            string uname = InputValidation.NullValidation();

            customer = admin.customerController.GetCustomer(uname);
            if (customer == null)
            {
                Console.WriteLine(Message.doesntExist);
                goto selectCustomer;
            }
            BookingsUI.BookTicketsUI(customer);

        }
        //VIEW ADMINS UI 
        public static void ViewAdminsUI(AdminObjects admin)
        {
           
            var admins= admin.adminController.ViewAdmins();
            Message.ViewAdmins();
            HelperClass.PrintUsers(admins);
            Message.AdminViewAdmins();
            Console.ResetColor();
            Console.WriteLine();
            AdminFuncOptions input;
            Console.Write(Message.ChooseNum);
            while (true)
            {
                input = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        RegistrationUI.AddNewUserUI(Role.Admin);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        AdminUI.ADMINUI(admin);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }
        }

        // VIEW ARTIST UI 
        public static void ViewArtistUI(AdminObjects admin)
        {
            ArtistUI.ViewArtistsUI(admin.artistController);
            Message.AdminViewArtist();
            AdminFuncOptions input;
            while (true)
            {
                Console.Write(Message.ChooseNum);
                input = (AdminFuncOptions)InputValidation.IntegerValidation();

                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        AddNewArtistUI(admin);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        AdminUI.ADMINUI(admin);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }

        }

        // VIEW VENUES UI 
        public static void ViewVenuesUI(AdminObjects admin)
        {
            VenueUI.ViewVenuesUI(admin.venueController);
            Message.AdminViewVenues();
            AdminFuncOptions input;
            Console.Write(Message.ChooseNum);
            while (true)
            {
                input = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        AddNewVenueUI(admin);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        AdminUI.ADMINUI(admin);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }

        }
        

        // VIEW ORGANIZERS UI 
        public static void ViewOrganizersUI(AdminObjects admin)
        {

            var organizers= admin.organizationController.ViewOrganizers();
            Message.ViewOrganizers();
            HelperClass.PrintUsers(organizers);
            Message.AdminViewOrganizer();
            Console.WriteLine();
            Console.ResetColor();
            AdminFuncOptions input;
            Console.Write(Message.ChooseNum);
            while (true)
            {
                input = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        RegistrationUI.AddNewUserUI(Role.Organizer);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        AdminUI.ADMINUI(admin);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }

        }

        // VIEW CUSTOMERS UI 
        public static void ViewCustomersUI(AdminObjects admin)
        {
            var customers = admin.customerController.ViewCustomers();
            Message.ViewCustomers();
            HelperClass.PrintUsers(customers);
            Message.AdminViewCustomers();
            Console.WriteLine();
            AdminFuncOptions input;
            Console.Write(Message.ChooseNum);
            while (true)
            {
                input = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        RegistrationUI.AddNewUserUI(Role.Customer);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        AdminUI.ADMINUI(admin);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }
            Console.ResetColor();

        }

        //ADD NEW ARTIST
        public static void AddNewArtistUI(AdminObjects admin)
        {
            Console.Write(Message.enterName);
            string name = InputValidation.NullValidation();
            DateTime dt = InputValidation.DateValidation();
            var artist = new Artist(name, dt);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if (admin.artistController.AddNewArtist(artist))
            {
                Console.WriteLine(Message.artistAdded);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(Message.errorOccurred);
            }
            AdminUI.ADMINUI(admin);
        }

        //ADD NEW VENUE
        public static void AddNewVenueUI(AdminObjects admin)
        {
            Console.Write(Message.enterPlace);
            string place = InputValidation.NullValidation();
            Venue venue = new Venue(place);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if (admin.venueController.AddNewVenue(venue))
            {
                Console.WriteLine(Message.venueAdded);
                Console.ResetColor();
                

            }
            else
            {
                Console.WriteLine(Message.errorOccurred);
            }
            AdminUI.ADMINUI(admin);

        }
    }
}
