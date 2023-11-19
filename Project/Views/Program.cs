using Project.Controller;
using Project.ControllerInterface;
using Project.Database;
using Project.DatabaseInterface;
using Project.ViewsInterface;

namespace Project.Views
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IArtistDbHandler artistDbHandler = ArtistDbHandler.ArtistDbInstance;
            IBookingDbHandler bookingDbHandler = BookingDbHandler.BookingDbInstance;
            IEventDbHandler eventDbHandler = EventDbHandler.EventDbInstance;
            IUserDbHandler userDbHandler = UserDbHandler.UserDbInstance;
            IVenueDbHandler venueDbHandler = VenueDbHandler.VenueDbInstance;
            IAuthController authController = AuthController.AuthObject;          
            IArtistController artistController = new ArtistController(artistDbHandler);
            IEventController eventController = new EventContoller(eventDbHandler);
            IVenueController venueController = new VenueController(venueDbHandler);
            IBookingController bookingController = new BookingController(bookingDbHandler);
            ICustomerController customerController = new CustomerController(userDbHandler);
            IAdminController adminController = new AdminController(userDbHandler);
            IOrganizerController organizerController = new OrganizerController(userDbHandler);
            IArtistUI artistUI = new ArtistUI(artistController);
            IEventUI eventUI = new EventUI(eventController);
            IVenueUI venueUI = new VenueUI(venueController);
            IBookingUI bookingUI = new BookingUI(bookingController, eventController,eventUI);
            ICustomerView customerView = new CustomerView(bookingUI, eventUI, bookingController, eventController);
            ICustomerUI customerUI = new CustomerUI(customerView, authController);
            IOrganizerView organizerView = new OrganizerView(eventController);
            IOrganizerUI organizerUI = new OrganizerUI(eventUI,organizerView,authController);
            IRegistration register = new Registration(authController);
            IAdminRemove adminRemove = new AdminRemove(eventController, eventUI);
            IAdminAdd adminAdd = new AdminAdd(artistController, venueController,customerController,organizerController, eventUI, bookingUI);
            IAdminView adminView = new AdminView(eventUI, artistUI, venueUI, register, adminAdd, adminRemove, artistController, adminController, bookingController, customerController, organizerController);
            IAdminUI adminUI = new AdminUI(adminView, authController);      
            IAuthenticate authenticate = new Authenticate(authController,adminUI,customerUI,organizerUI);
            IHomePage homePage = new HomePage(authenticate, register);
            try
            {
               homePage.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong!!");
                HelperClass.LogException(ex, "Something went wrong");
            }
        }
    }
}
