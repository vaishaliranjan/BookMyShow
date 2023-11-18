using Project.Controller;
using Project.ControllerInterface;
using Project.Helpers;
using Project.Models;
using Project.ViewsInterface;

namespace Project.Views
{ 
    public class EventUI:IEventUI
    {
        static int eventIdInc = Event.EventIDInc;
        public IEventController EventController { get; }
        public IArtistUI ArtistUI { get; }
        public IVenueUI VenueUI { get; }
        public IArtistController ArtistController { get; }
        public IVenueController VenueController { get; }
        public EventUI(IEventController eventController)
        {
            EventController=eventController;
        }
        public void ViewEvents()
        {
            var events = EventController.GetAll();
            Message.ViewEvents();
            Print.ShowEvents(events);
        }
             
        public void CreateEvent(string organizerUsername) 
        {
            var artist = SelectArtist();
            var venue = SelectVenue();
            var eventName = HelperClass.EnterEventName();
            var tickets = HelperClass.EnterNumberOfTickets();   
            var price = HelperClass.EnterPricePerTicket();
            var initialTick = tickets;
            var newEvent = new Event(++eventIdInc, eventName, organizerUsername, artist, venue, tickets, initialTick, price);
            if (EventController.Add(newEvent))
            {
                Message.EventAdded();
            }
            else
            {
                Console.WriteLine(Message.ErrorOccurred); 
            }  
        }

        public void CancelEvent()
        {  
            Console.Write(Message.EnterEventId);
            var deleteEventId = InputValidation.IntegerValidation();
            if (EventController.Delete(deleteEventId))
            {
                Message.EventDeleted();
            }
            else
            {
                Message.CantCancelEvent(); 
            }
        }


        private Artist SelectArtist()
        {
            Console.WriteLine(Message.SelectArtist);
            ArtistUI.ViewArtists();
            Artist artist;
            while (true)
            {
                Console.Write(Message.EnterArtistId);
                int artistId = InputValidation.IntegerValidation();
                artist = ArtistController.GetById(artistId);
                if (artist == null)
                {
                    Console.WriteLine(Message.DoesNotExist);
                    continue;
                }
                break;
            }
            return artist;
        }
        private Venue SelectVenue()
        {
            Console.WriteLine(Message.SelectVenue);
            VenueUI.ViewVenues();
            Venue venue;
            while (true)
            {
                Console.Write(Message.EnterVenueId);

                int venueId = InputValidation.IntegerValidation();
                venue = VenueController.GetById(venueId);
                if (venue == null)
                {
                    Console.WriteLine(Message.DoesNotExist);
                    continue;
                }
                break;
            }
            return venue;
        }


    }
}
