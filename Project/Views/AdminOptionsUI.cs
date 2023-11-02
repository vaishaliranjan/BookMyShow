using Project.Controller;
using Project.Enum;
using Project.Models;
using Project.UI;
using Project.UILayer;


namespace Project.Views
{
    internal class AdminOptionsUI
    {
        //************************************************* VIEW ADMINS UI ************************************************
        public static void ViewAdminsUI(Admin admin)
        {
            AdminController adminController = new AdminController();
            adminController.ViewAdmins();
            Message.AdminViewAdmins();
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

        //************************************************ VIEW ARTIST UI ****************************************
        public static void ViewArtistUI(Admin admin)
        {
            ArtistController artistController = new ArtistController();
            artistController.ViewArtists();
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
                       AdminUI. ADMINUI(admin);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }

        }

        //************************************************* VIEW VENUES UI ************************************************
        public static void ViewVenuesUI(Admin admin)
        {
            VenueController.ViewVenues();
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

        //************************************************ VIEW Events UI ****************************************
        public static void ViewEventsUI(Admin admin)
        {
            EventContoller.ViewEvents(admin, Role.Admin);
            Message.AdminViewEvents();
            AdminFuncOptions input;
            Console.Write(Message.ChooseNum);
            while (true)
            {
                input = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        EventUI.CreateEventUI(admin, Role.Admin);
                       AdminUI. ADMINUI(admin);
                        break;

                    case AdminFuncOptions.Cancel:
                        EventUI.CancelEventUI(admin, Role.Admin);
                        AdminUI.ADMINUI(admin);
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

        //************************************************ VIEW ORGANIZERS UI ****************************************
        public static void ViewOrganizersUI(Admin admin)
        {

            OrganizerController.ViewOrganizers();
            Message.AdminViewOrganizer();
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

        //************************************************* VIEW CUSTOMERS UI ************************************************
        public static void ViewCustomersUI(Admin admin)
        {
            CustomerController.ViewCustomers();
            Message.AdminViewCustomers();
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

        }

        //ADD NEW ARTIST
        public static void AddNewArtistUI(Admin admin)
        {
            Console.Write(Message.enterName);
            string name = InputValidation.NullValidation();
            DateTime dt = InputValidation.DateValidation();
            var artist = new Artist(name, dt);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            ArtistController.AddNewArtist(artist);
            Console.ResetColor();
            AdminUI.ADMINUI(admin);
        }

        //ADD NEW VENUE
        public static void AddNewVenueUI(Admin admin)
        {
            Console.Write("Enter Place:");
            string place = InputValidation.NullValidation();
            Venue venue = new Venue(place);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            VenueController.AddNewVenue(venue);
            Console.ResetColor();
            AdminUI.ADMINUI(admin);
        }
    }
}
