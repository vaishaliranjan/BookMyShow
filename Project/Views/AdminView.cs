
using Project.ControllerInterface;
using Project.Enum;
using Project.Helpers;
using Project.Models;
using Project.ViewsInterface;

namespace Project.Views
{
    public class AdminView: IAdminView
    {
        public IEventUI EventUI { get; }
        public IArtistUI ArtistUI { get; }
        public IVenueUI VenueUI { get; }
        public IRegistration Register { get; }
        public IAdminAdd AdminAdd { get; }
        public IAdminRemove AdminRemove { get; }
        public IArtistController ArtistController { get; }
        public IAdminController AdminController { get; }
        public IBookingController BookingController { get; }
        public ICustomerController CustomerController { get; }
        public IOrganizerController OrganizerController { get; }

        public AdminView(IEventUI eventUI,IArtistUI artistUI, IVenueUI venueUI, IRegistration register, IAdminAdd adminAdd, IAdminRemove adminRemove, IArtistController artistController, IAdminController adminController, IBookingController bookingController, ICustomerController customerController, IOrganizerController organizerController)
        {
            EventUI = eventUI;
            ArtistUI = artistUI;
            VenueUI = venueUI;
            Register= register;
            AdminAdd= adminAdd;
            AdminRemove= adminRemove;
            ArtistController= artistController;
            AdminController= adminController;
            BookingController = bookingController;
            CustomerController = customerController;
            OrganizerController = organizerController;
        }


        public void ViewEvents(User admin)
        {
            EventUI.ViewEvents();
            Message.AdminViewEventsOptions();
            AdminFuncOptions ip;
            while (true)
            {
                Console.Write(Message.ChooseNum);
                ip = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (ip)
                {
                    case AdminFuncOptions.AddNew:
                        AdminAdd.AddNewEvent(admin);
                        break;

                    case AdminFuncOptions.Cancel:
                        AdminRemove.CancelEvent(admin);
                        break;

                    case AdminFuncOptions.Exit:
                        break;

                    default:
                        Console.WriteLine(Message.InvalidInputMessage);
                        continue;
                }
                break;
            }
        }


        public void ViewArtists(User admin)
        {
            ArtistUI.ViewArtists();
            Message.AdminViewArtistOptions();
            AdminFuncOptions input;
            while (true)
            {
                Console.Write(Message.ChooseNum);
                input = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        AdminAdd.AddNewArtist(admin);
                        break;

                    case AdminFuncOptions.Exit:
                        break;

                    default:
                        Console.WriteLine(Message.InvalidInputMessage);
                        continue;
                }
                break;
            }
        }


        public void ViewVenues(User admin)
        {
            VenueUI.ViewVenues();
            Message.AdminViewVenuesOptions();
            AdminFuncOptions input;
            while (true)
            {
                Console.Write(Message.ChooseNum);
                input = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        AdminAdd.AddNewVenue(admin);
                        break;

                    case AdminFuncOptions.Exit:
                        break;

                    default:
                        Console.WriteLine(Message.InvalidInputMessage);
                        continue;
                }
                break;
            }
        }



        public void ViewOrganizers(User admin)
        {

            var organizers = OrganizerController.GetAll();
            Message.ViewOrganizers();
            Print.PrintUsers(organizers);
            Message.AdminViewOrganizerOptions();           
            AdminFuncOptions input;
            while (true)
            {
                Console.Write(Message.ChooseNum);
                input = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        Register.RegisterUser(Role.Organizer);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine(Message.InvalidInputMessage);
                        continue;
                }
                break;
            }
            Console.ResetColor();
        }


        public void ViewCustomers(User admin)
        {
            var customers = CustomerController.GetAll();
            Message.ViewCustomers();
            Print.PrintUsers(customers);
            Message.AdminViewCustomerOptions();
            AdminFuncOptions input;
            while (true)
            {
                Console.Write(Message.ChooseNum);
                input = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        Register.RegisterUser(Role.Customer);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine(Message.InvalidInputMessage);
                        continue;
                }
                break;
            }
            Console.ResetColor();
        }
        public void ViewAdmins(User admin)
        {
            var admins = AdminController.GetAll();
            Message.ViewAdmins();
            Print.PrintUsers(admins);
            Message.AdminViewAdminOptions();
            Console.ResetColor();
            AdminFuncOptions input;
            while (true)
            {
                Console.Write(Message.ChooseNum);
                input = (AdminFuncOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case AdminFuncOptions.AddNew:
                        Register.RegisterUser(Role.Admin);
                        break;

                    case AdminFuncOptions.Exit:
                        break;

                    default:
                        Console.WriteLine(Message.InvalidInputMessage);
                        continue;
                }
                break;
            }
        }
        public void ViewBookings(User admin)
        {
            var bookings = BookingController.GetAll();
            Print.ShowBookings(bookings);
            Message.AdminViewBookingsOptions();
            BookingsOptions input;
            while (true)
            {
                Console.Write(Message.ChooseNum);
                input = (BookingsOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case BookingsOptions.AddNewBooking:
                        AdminAdd.AddNewBooking(admin);
                        break;

                    case BookingsOptions.Exit:
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine(Message.InvalidInputMessage);
                        continue;
                }
                break;
            }
        }      
    }
}
