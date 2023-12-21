using Project.ControllerInterface;
using Project.Enum;
using Project.Models;
using Project.Views;
using Project.ViewsInterface;

namespace Project.Views
{
    public class AdminUI:IAdminUI
    {
        public IAuthController AuthController { get; }
        public IAdminView AdminView { get; }
        public AdminUI(IAdminView adminView, IAuthController authController)
        {
            AdminView = adminView;
            AuthController = authController;
        }
        public void AdminPage(User admin)
        {
            Message.AdminPage();
            AdminOptions input;
            while (true)
            {
                Console.Write(Message.ChooseNum);
                input = (AdminOptions)InputValidation.IntegerValidation();          
                switch (input)
                {
                    case AdminOptions.ViewAdmins:
                        AdminView.ViewAdmins(admin);
                        AdminPage(admin);
                        break;

                    case AdminOptions.ViewArtists:
                        AdminView.ViewArtists(admin);
                        AdminPage(admin);
                        break;

                    case AdminOptions.ViewVenues:
                        AdminView.ViewVenues(admin);
                        AdminPage(admin);
                        break;

                    case AdminOptions.ViewEvents:
                        AdminView.ViewEvents(admin);
                        AdminPage(admin);
                        break;
                        
                    case AdminOptions.ViewOrganizers:
                        AdminView.ViewOrganizers(admin);
                        AdminPage(admin);
                        break;

                    case AdminOptions.ViewCustomers:
                        AdminView.ViewCustomers(admin);
                        AdminPage(admin);
                        break;

                    case AdminOptions.ViewBookings:
                        AdminView.ViewBookings(admin);
                        AdminPage(admin);
                        break;

                    case AdminOptions.LogOut:
                        AuthController.Logout();
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
