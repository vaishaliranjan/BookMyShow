using Project.ControllerInterface;
using Project.Helpers;
using Project.Models;
using Project.ViewsInterface;
namespace Project.Views
{
    public class AdminAdd:IAdminAdd
    {
        

        public IArtistController ArtistController { get; }
        public IVenueController VenueController { get; }
        public IOrganizerController OrganizerController { get; }
        public ICustomerController CustomerController { get; }
        public IEventUI EventUI { get; }
        public IBookingUI BookingUI { get; }    
        

        public AdminAdd( IArtistController artistController, IVenueController venueController,  ICustomerController customerController, IOrganizerController organizerController,IEventUI eventUI, IBookingUI bookingUI)
        {
            ArtistController = artistController;
            VenueController = venueController;
            CustomerController = customerController;
            OrganizerController = organizerController;
            EventUI = eventUI;
            BookingUI = bookingUI;
        }

        public void AddNewEvent(User admin)
        {
            var organizer = SelectOrganizerOfEvent(admin);
            EventUI.CreateEvent(organizer.Username);
        }
        
        public void AddNewBooking(User admin)
        {
            var customer= SelectCustomerForBooking(admin);    
            BookingUI.BookTickets(customer.Username);
        }

        public void AddNewArtist(User admin)
        {
            var artist = HelperClass.EnterArtistDetails();
            if (ArtistController.Add(artist))
            {
                Console.WriteLine(Message.ArtistAdded);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(Message.ErrorOccurred);
            }
        }
   
        public void AddNewVenue(User admin)
        {
            Venue venue = HelperClass.EnterVenueDetails();    
            if (VenueController.Add(venue))
            {
                Console.WriteLine(Message.VenueAdded);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(Message.ErrorOccurred);
            }
        }

        private User SelectOrganizerOfEvent(User admin)
        {
            User organizer;
            var organizers = OrganizerController.GetAll();
            Print.PrintUsers(organizers);
            while (true)
            {
                Console.WriteLine(Message.SelectOrganizer);
                Console.Write(Message.EnterUsername);
                string uname = InputValidation.StringValidation();
                organizer = OrganizerController.GetByUsername(uname);
                if (organizer == null)
                {
                    Console.WriteLine(Message.DoesNotExist);
                    continue;
                }
                break;
            }
            return organizer;
        }
        private User SelectCustomerForBooking(User admin)
        {
            User customer;
            var customers = CustomerController.GetAll();
            Print.PrintUsers(customers);
            while (true)
            {
                Console.WriteLine(Message.SelectCustomer);
                Console.Write(Message.EnterUsername);
                string uname = InputValidation.StringValidation();
                customer = CustomerController.GetByUsername(uname);
                if (customer == null)
                {
                    Console.WriteLine(Message.DoesNotExist);
                    continue;
                }
                break;
            }
            return customer;
        }
    }
}
