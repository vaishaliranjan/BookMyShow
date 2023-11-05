using Project.Controller;
using Project.Models;
using Project.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views
{
    internal class OrganizerObjects:AllUserObjects
    {
        public Organizer realOrganizerObject;
        public ArtistController artistController;
        public VenueController venueController;
        public EventContoller eventContoller;
        public OrganizerController organizationController;

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
