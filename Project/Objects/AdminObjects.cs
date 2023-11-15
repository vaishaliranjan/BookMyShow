using Project.Controller;
using Project.ControllerInterface;
using Project.Models;


namespace Project.Objects
{
    public class AdminObjects 
    {
        public Admin realAdminObject;
        public IAdminController adminController;
        public IArtistController artistController;
        public ICustomerController customerController;
        public IOrganizerController organizationController;
        public IVenueController venueController;
        public IBookingController bookingController;
        public IEventController eventContoller;


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
