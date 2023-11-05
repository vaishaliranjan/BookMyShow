using Project.Controller;
using Project.Enum;
using Project.Models;
using Project.UILayer;


namespace Project.Views
{
    internal class EventUI
    {
        public static int eventIdInc = Event.eventIDInc;
        static void ShowEvents(List<Event> events)
        {
            foreach (Event e in events)
            {
                Console.WriteLine();
                Console.WriteLine("Event Id: " + e.Id);
                Console.WriteLine("Name: " + e.Name);
                Console.WriteLine("Timing: " + e.artist.timing);
                Console.WriteLine("Artist: " + e.artist.Name);
                Console.WriteLine("Venue: " + e.venue.Place);
                Console.WriteLine("Number of tickets left: " + e.NumOfTicket);
                Console.WriteLine("Price per ticket: " + e.Price);
                Console.WriteLine();
            }
        }
        public static void ViewEventsUI(Role role, string username = null ) 
        {
            EventContoller eventContoller = new EventContoller();
            var events=eventContoller.ViewEvents();
            if(events != null)
            {
                Message.ViewEvents();
                if ( role == Role.Admin || role == Role.Customer)
                {
                    ShowEvents(events);
                    return;
                    
                }
                else if (role == Role.Organizer)
                {
                    var organizerEvents = events.FindAll(e => e.organizer.Username == username);
                    ShowEvents(organizerEvents);
                    return;
                }
            }
            
           


        }
        
        public static void CreateEventUI(Role role, Organizer organizerOfEvent) 
        {
            ArtistController artistController= new ArtistController();
            VenueController venueController = new VenueController();
            EventContoller eventContoller = new EventContoller();
            Console.WriteLine();
            Console.WriteLine(Message.selectArtist);
            ArtistUI.ViewArtistsUI(artistController);
            Artist choosenArtist = null;
        selectArtistId: Console.Write(Message.artistId);
            int artistId = InputValidation.IntegerValidation();
         
                choosenArtist = artistController.SelectArtist(artistId);
                if (choosenArtist == null)
                {
                    Console.WriteLine(Message.doesntExist);
                    goto selectArtistId;
                }
            Console.WriteLine();
            Console.WriteLine(Message.selectVenue);
            VenueUI.ViewVenuesUI(venueController);
            selectVenueId:  Console.Write(Message.venueId);
            Venue choosenVenue = null;
            int venueId= InputValidation.IntegerValidation();
           
               
                choosenVenue=venueController.SelectVenue(venueId);
                if (choosenVenue == null)
                {
                    goto selectVenueId;
                }

            string eventName;
            Console.Write(Message.eventName);
            eventName = InputValidation.NullValidation();
            Console.Write(Message.numOfTickets);
            int tickets = InputValidation.IntegerValidation();
            Console.Write(Message.pricePerTicket);
            int price= InputValidation.IntegerValidation();
            int initialTick = tickets;
            var newEvent = new Event()
            {
                Id= ++eventIdInc,
                Name= eventName,
                organizer = organizerOfEvent,
                artist = choosenArtist,
                venue= choosenVenue,
                NumOfTicket=tickets,
                initialTickets=initialTick,
                Price=price

            };
            if (eventContoller.AddEvent(newEvent))
            {
                Message.EventAdded();
            }
            else
            {
                Console.WriteLine(Message.errorOccurred); 
            }
           

        }

        public static void CancelEventUI()
        {
            EventContoller eventContoller = new EventContoller();
            Console.Write(Message.eventId);
            int deleteEventId = InputValidation.IntegerValidation();
            if (eventContoller.DeleteEvent(deleteEventId))
            {
                Message.EventDeleted();
              
            }
            else
            {
                Message.CantCancelEvent();
                
            }
            

        }
    }
}
