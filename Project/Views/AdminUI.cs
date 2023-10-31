using Project.BusinessLayer;
using Project.Enum;
using Project.UI;
using Project.Views;


namespace Project.UILayer
{
    internal class AdminUI
    {
        
        
        public static void ADMINUI(string username)
        {
            Message.AdminPage();
            AdminOptions input;
            Console.Write("Choose any number: ");
            while (true)
            {
                
                input = (AdminOptions)InputValidation.IntegerValidation();
               
                switch (input)
                {
                    case AdminOptions.ViewAdmins:
                        ViewAdminsUI(username);
                        break;

                    case AdminOptions.ViewArtists:
                        ViewArtistUI(username);
                        break;

                    case AdminOptions.ViewVenues:
                        ViewVenuesUI(username);
                        break;

                    case AdminOptions.ViewEvents:
                        ViewEventsUI(username);
                        break;

                    case AdminOptions.ViewOrganizers:
                        ViewOrganizersUI(username);
                        break;

                    case AdminOptions.ViewCustomers:
                        ViewCustomersUI(username);
                        break;

                    case AdminOptions.ViewBookings:
                        BookingsUI.ViewBookingsUI(username, Role.Admin);
                        break;

                    case AdminOptions.LogOut:
                        AuthManager<User>.AuthObject.Logout();
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }   
        }

       

        //************************************************ VIEW Events UI ****************************************
        public static void ViewEventsUI(string username)
        {
            Event.ViewEvents(username, Role.Admin);
            Message.AdminViewEvents();
            AdminFuncOptions input;
            Console.Write("Choose any number: ");
            while (true)
            {
                Console.Write("Choose any number: ");
                input = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        EventUI.CreateEventUI(username, Role.Admin);
                        ADMINUI(username);
                        break;

                    case AdminFuncOptions.Cancel:
                        EventUI.CancelEventUI(username, Role.Admin);
                        ADMINUI(username);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        ADMINUI(username);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }
            
        }


        //************************************************ VIEW ORGANIZERS UI ****************************************
        public static void ViewOrganizersUI( string username)
        {
            
            Organizer.ViewOrganizers();
            Message.AdminViewOrganizer();
            AdminFuncOptions input;
            Console.Write("Choose any number: ");
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
                        ADMINUI(username);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }
            

           
          
        }


        //************************************************ VIEW ARTIST UI ****************************************
        public static void ViewArtistUI(string username)
        {
       
            Artist.ViewArtists();
            Message.AdminViewArtist();
            AdminFuncOptions input;
            while (true)
            {
                Console.Write("Choose any number: ");
                input = (AdminFuncOptions) InputValidation.IntegerValidation();

                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        AddNewArtistUI(username);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        ADMINUI(username);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }

        }

        //************************************************* VIEW CUSTOMERS UI ************************************************
        public static void ViewCustomersUI(string username)
        {
            Customer.ViewCustomers();
            Message.AdminViewCustomers();
            AdminFuncOptions input;
            Console.Write("Choose any number: ");
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
                        ADMINUI(username);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }
           
        }


        //************************************************* VIEW VENUES UI ************************************************
        public static void ViewVenuesUI(string username)
        {
            Venue.ViewVenues();
            Message.AdminViewVenues();
            AdminFuncOptions input;
            Console.Write("Choose any number: ");
            while (true)
            {
                input = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        AddNewVenueUI(username);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        ADMINUI(username);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }
           
        }

        //************************************************* VIEW ADMINS UI ************************************************
        public static void  ViewAdminsUI(string username)
        {
            Admin.ViewAdmins();
            Message.AdminViewAdmins();
            AdminFuncOptions input;
            Console.Write("Choose any number: ");
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
                        ADMINUI(username);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }
        }
        //ADD NEW ARTIST
        public static void AddNewArtistUI(string username)
        {
            Console.Write("Enter Name:");
            string name = InputValidation.NullValidation();   
            DateTime dt = InputValidation.DateValidation();
            var artist = new Artist(name, dt);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Artist.AddNewArtist(artist);
            Console.ResetColor();
            ADMINUI(username);
        }

        //ADD NEW VENUE
        public static void AddNewVenueUI(string username)
        {
            Console.Write("Enter Place:");
            string place = InputValidation.NullValidation();
            Venue venue = new Venue(place);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Venue.AddNewVenue(venue);
            Console.ResetColor();
            ADMINUI(username);
        }

        
    }
}
