using Project.Models;
using Project.Objects;
using Project.UILayer;

namespace Project.Views
{
    public class AdminAdd
    {
        static int artistId = Artist.ArtistIdInc;
        static int venueId = Venue.VenueIdInc;
        public static void AddNewEvent(AdminObjects admin)
        {
            var organizerOfEvent = SelectOrganizerOfEvent(admin);
            EventUI.CreateEvent(organizerOfEvent);
            AdminUI.AdminPage(admin);
        }
        
        public static void AddNewBooking(AdminObjects admin)
        {
            var customerForBooking= SelectCustomerForBooking(admin);    
            BookingsUI.BookTickets(customerForBooking);
            AdminUI.AdminPage(admin);
        }


        public static void AddNewArtist(AdminObjects admin)
        {
            var artist = EnterArtistDetails();
            if (admin.artistController.Add(artist))
            {
                Console.WriteLine(Message.artistAdded);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(Message.errorOccurred);
            }
            AdminUI.AdminPage(admin);
        }

       
        public static void AddNewVenue(AdminObjects admin)
        {
            var venue = EnterVenueDetails();    
            if (admin.venueController.Add(venue))
            {
                Console.WriteLine(Message.venueAdded);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(Message.errorOccurred);
            }
            AdminUI.AdminPage(admin);

        }

        static Venue EnterVenueDetails()
        {
            Console.Write(Message.enterPlace);
            string place = InputValidation.StringValidation();
            Venue venue = new Venue(++venueId, place);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            return venue;
        }
        static Artist EnterArtistDetails()
        {
            Console.Write(Message.enterName);
            string name = InputValidation.StringValidation();
            DateTime dt = InputValidation.DateValidation();
            var artist = new Artist(++artistId, name, dt);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            return artist;
        }
        static Organizer SelectOrganizerOfEvent(AdminObjects admin)
        {
            Organizer organizer = null;
            var organizers = admin.organizationController.GetAll();
            Print.PrintUsers(organizers);
            while (true)
            {
                Console.WriteLine(Message.selectOrganizer);
                Console.Write(Message.enterUsername);
                string uname = InputValidation.StringValidation();
                organizer = admin.organizationController.GetByUsername(uname);
                if (organizer == null)
                {
                    Console.WriteLine(Message.doesntExist);
                    continue;
                }
                break;
            }
            return organizer;
        }
        static Customer SelectCustomerForBooking(AdminObjects admin)
        {
            Customer customer = null;
            var customers = admin.customerController.GetAll();
            Print.PrintUsers(customers);
            while (true)
            {
                Console.WriteLine(Message.selectCustomer);
                Console.Write(Message.enterUsername);
                string uname = InputValidation.StringValidation();

                customer = admin.customerController.GetByUsername(uname);
                if (customer == null)
                {
                    Console.WriteLine(Message.doesntExist);
                    continue;
                }
                break;
            }
            return customer;
        }
    }
}
