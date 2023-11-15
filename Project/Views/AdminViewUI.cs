
using Project.Enum;
using Project.Objects;
using Project.UI;
using Project.UILayer;

namespace Project.Views
{
    public class AdminViewUI
    {
        public static void ViewEvents(AdminObjects admin)
        {
            EventUI.ViewEvents(admin.eventContoller);
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
                        AdminUI.AdminPage(admin);
                        break;

                    case AdminFuncOptions.Cancel:
                        AdminDelete.CancelEvent(admin);
                        AdminUI.AdminPage(admin);
                        break;

                    case AdminFuncOptions.Exit:
                        AdminUI.AdminPage(admin);
                        break;

                    default:
                        Console.WriteLine(Message.invalidInput);
                        continue;
                }
                break;
            }
        }


        public static void ViewArtists(AdminObjects admin)
        {
            ArtistUI.ViewArtists(admin.artistController);
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
                        Console.WriteLine();
                        AdminUI.AdminPage(admin);
                        break;

                    default:
                        Console.WriteLine(Message.invalidInput);
                        continue;
                }
                break;
            }
        }


        public static void ViewVenues(AdminObjects admin)
        {
            VenueUI.ViewVenues(admin.venueController);
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
                        AdminUI.AdminPage(admin);
                        break;

                    default:
                        Console.WriteLine(Message.invalidInput);
                        continue;
                }
                break;
            }
        }



        public static void ViewOrganizers(AdminObjects admin)
        {

            var organizers = admin.organizationController.GetAll();
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
                        RegistrationUI.AddNewUser(Role.Organizer);
                        AdminUI.AdminPage(admin);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        AdminUI.AdminPage(admin);
                        break;

                    default:
                        Console.WriteLine(Message.invalidInput);
                        continue;
                }
                break;
            }
            Console.ResetColor();
        }


        public static void ViewCustomers(AdminObjects admin)
        {
            var customers = admin.customerController.GetAll();
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
                        RegistrationUI.AddNewUser(Role.Customer);
                        AdminUI.AdminPage(admin);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        AdminUI.AdminPage(admin);
                        break;

                    default:
                        Console.WriteLine(Message.invalidInput);
                        continue;
                }
                break;
            }
            Console.ResetColor();
        }
        public static void ViewAdmins(AdminObjects admin)
        {
            var admins = admin.adminController.GetAll();
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
                        RegistrationUI.AddNewUser(Role.Admin);
                        AdminUI.AdminPage(admin);
                        break;

                    case AdminFuncOptions.Exit:
                        Console.WriteLine();
                        AdminUI.AdminPage(admin);
                        break;

                    default:
                        Console.WriteLine(Message.invalidInput);
                        continue;
                }
                break;
            }
        }
        public static void ViewBookings(AdminObjects admin)
        {
            var bookings = admin.bookingController.GetAll();
            BookingsUI.ShowBookings(bookings);
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
                        AdminUI.AdminPage(admin);
                        break;

                    case BookingsOptions.Exit:
                        Console.WriteLine();
                        AdminUI.AdminPage(admin);
                        break;

                    default:
                        Console.WriteLine(Message.invalidInput);
                        continue;
                }
                break;
            }
        }      
    }
}
