using Project.Controller;
using Project.ControllerInterface;
using Project.Models;
using Project.Objects;


namespace Project.Views
{
    internal class OrganizerObjects
    {
        public Organizer realOrganizerObject;
        public IArtistController artistController;
        public IVenueController venueController;
        public IEventController eventContoller;
        public IOrganizerController organizationController;

        public OrganizerObjects(Organizer organizer)
        {
            this.realOrganizerObject = organizer;
            artistController = new ArtistController();
            venueController = new VenueController();
            eventContoller = new EventContoller();
            organizationController = new OrganizerController();
        }

    }
}
