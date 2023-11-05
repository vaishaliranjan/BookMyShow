using Project.Controller;
using Project.Models;


namespace Project.Objects
{
    public class AdminObjects : AllUserObjects
    {
        public Admin realAdminObject;
        public AdminController adminController;
        public ArtistController artistController;
        public CustomerController customerController;
        public OrganizerController organizationController;
        public VenueController venueController;
        public BookingController bookingController;
        public EventContoller eventContoller;


        public AdminObjects(Admin admin)
        {
            realAdminObject = admin;
            adminController = new AdminController();
            artistController = new ArtistController();
            customerController = new CustomerController();
            organizationController = new OrganizerController();
            bookingController = new BookingController();
            eventContoller = new EventContoller();
            venueController = new VenueController();

        }


    }
}
