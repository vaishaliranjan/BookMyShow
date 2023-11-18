using Project.ControllerInterface;
using Project.Helpers;
using Project.ViewsInterface;

namespace Project.Views
{
    public class VenueUI:IVenueUI
    {
        public IVenueController VenueController { get; }
        public VenueUI(IVenueController venueController)
        {
            VenueController = venueController;
        }
        public void ViewVenues()
        {
            var venues = VenueController.GetAll();
            Print.ShowVenues(venues);
        }
         
    }
}
