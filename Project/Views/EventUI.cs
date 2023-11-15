using Project.Controller;
using Project.ControllerInterface;
using Project.Models;


namespace Project.Views
{
    internal class EventUI
    {
        static int eventIdInc = Event.EventIDInc;
        public static void ViewEvents(IEventController eventController)
        {
            var events = eventController.GetAll();
            Message.ViewEvents();
            ShowEvents(events);
        }
        public static void ShowEvents(List<Event> events)
        {
            if (events != null)
            {
                foreach (Event e in events)
                {
                    Console.WriteLine();
                    Console.WriteLine("Event Id: " + e.Id);
                    Console.WriteLine("Name: " + e.Name);
                    Console.WriteLine("Timing: " + e.Artist.Timing);
                    Console.WriteLine("Artist: " + e.Artist.Name);
                    Console.WriteLine("Venue: " + e.Venue.Place);
                    Console.WriteLine("Number of tickets left: " + e.NumOfTicket);
                    Console.WriteLine("Price per ticket: " + e.Price);
                    Console.WriteLine();
                }
            }
            else
            {
                Error.NotFound("events");
            }
        }
       

       
        
        public static void CreateEvent(Organizer organizerOfEvent) 
        {
            var artist = SelectArtist();
            var venue = SelectVenue();
            var eventName = EnterEventName();
            var tickets = EnterNumberOfTickets();   
            var price = EnterPricePerTicket();
            var initialTick = tickets;
            IEventController eventContoller = new EventContoller();
            var newEvent = new Event(++eventIdInc, eventName, organizerOfEvent, artist, venue, tickets, initialTick, price);
            if (eventContoller.Add(newEvent))
            {
                Message.EventAdded();
            }
            else
            {
                Console.WriteLine(Message.errorOccurred); 
            }  
        }

        public static void CancelEvent(IEventController eventController)
        {  
            Console.Write(Message.eventId);
            var deleteEventId = InputValidation.IntegerValidation();
            if (eventController.Delete(deleteEventId))
            {
                Message.EventDeleted();
            }
            else
            {
                Message.CantCancelEvent(); 
            }
        }


        static Artist SelectArtist()
        {
            IArtistController artistController = new ArtistController();
            Console.WriteLine(Message.selectArtist);
            ArtistUI.ViewArtists(artistController);
            Artist artist = null;
            while (true)
            {
                Console.Write(Message.artistId);
                int artistId = InputValidation.IntegerValidation();
                artist = artistController.GetById(artistId);
                if (artist == null)
                {
                    Console.WriteLine(Message.doesntExist);
                    continue;
                }
                break;
            }
            return artist;
        }
        static Venue SelectVenue()
        {
            IVenueController venueController = new VenueController();
            Console.WriteLine(Message.selectVenue);
            VenueUI.ViewVenues(venueController);
            Venue venue = null;
            while (true)
            {
                Console.Write(Message.venueId);

                int venueId = InputValidation.IntegerValidation();
                venue = venueController.GetById(venueId);
                if (venue == null)
                {
                    Console.WriteLine(Message.doesntExist);
                    continue;
                }
                break;
            }
            return venue;
        }

        static string EnterEventName()
        {
            Console.Write(Message.eventName);
            var eventName = InputValidation.StringValidation();
            return eventName;
        }
        static int EnterNumberOfTickets()
        {
            Console.Write(Message.numOfTickets);
            var tickets = InputValidation.IntegerValidation();
            return tickets;
        }

        static double EnterPricePerTicket()
        {
            Console.Write(Message.pricePerTicket);
            double price = InputValidation.FloatValidation();
            return price;
        }
    }
}
