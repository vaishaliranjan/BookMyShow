using Project.BusinessLayer;
using Project.Controller;
using Project.Enum;
using Project.Models;
using Project.UI;
using Project.Views;


namespace Project.UILayer
{
    internal class AdminUI
    {
        
        
        public static void ADMINUI(Admin admin)
        {
            Message.AdminPage();
            AdminOptions input;
            Console.Write(Message.ChooseNum);
            while (true)
            {
                input = (AdminOptions)InputValidation.IntegerValidation();
               
                switch (input)
                {
                    case AdminOptions.ViewAdmins:
                        AdminOptionsUI.ViewAdminsUI(admin);
                        break;

                    case AdminOptions.ViewArtists:
                        AdminOptionsUI.ViewArtistUI(admin);
                        break;

                    case AdminOptions.ViewVenues:
                        AdminOptionsUI.ViewVenuesUI(admin);
                        break;

                    case AdminOptions.ViewEvents:
                        AdminOptionsUI.ViewEventsUI(admin);
                        break;

                    case AdminOptions.ViewOrganizers:
                       AdminOptionsUI.ViewOrganizersUI(admin);
                        break;

                    case AdminOptions.ViewCustomers:
                       AdminOptionsUI.ViewCustomersUI(admin);
                        break;

                    case AdminOptions.ViewBookings:
                        BookingsUI.ViewBookingsUI(admin, Role.Admin);
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
    }
}
