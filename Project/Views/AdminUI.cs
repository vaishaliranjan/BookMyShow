using Project.BusinessLayer;
using Project.Enum;
using Project.Objects;
using Project.Views;


namespace Project.UILayer
{
    internal class AdminUI
    {
        public static void AdminPage(AdminObjects admin)
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
                        AdminViewUI.ViewAdmins(admin);
                        break;

                    case AdminOptions.ViewArtists:
                        AdminViewUI.ViewArtists(admin);
                        break;

                    case AdminOptions.ViewVenues:
                        AdminViewUI.ViewVenues(admin);
                        break;

                    case AdminOptions.ViewEvents:
                        AdminViewUI.ViewEvents(admin);
                        break;
                        
                    case AdminOptions.ViewOrganizers:
                       AdminViewUI.ViewOrganizers(admin);
                        break;

                    case AdminOptions.ViewCustomers:
                       AdminViewUI.ViewCustomers(admin);
                        break;

                    case AdminOptions.ViewBookings:
                        AdminViewUI.ViewBookings(admin);
                        
                        break;

                    case AdminOptions.LogOut:
                        AuthController.AuthObject.Logout();
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
