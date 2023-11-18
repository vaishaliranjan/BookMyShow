

namespace Project.ViewsInterface
{
    public interface IAdminView
    {
        void ViewEvents(Models.User admin);
        void ViewArtists(Models.User admin);
        void ViewVenues(Models.User admin);
        void ViewOrganizers(Models.User admin);
        void ViewCustomers(Models.User admin);
        void ViewAdmins(Models.User admin);
        void ViewBookings(Models.User admin);
    }
}
