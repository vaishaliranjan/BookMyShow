using Project.BusinessLayer;
using Project.UILayer;
using System.Runtime.CompilerServices;

namespace Project.Views
{
    internal class EventUI
    {
        public static int eventIDInc = 108;
        public static void CreateEventUI(string username, Role role)
        {
            Console.WriteLine();
            Console.WriteLine("Select Artist: ");
            Artist.ViewArtists();
            Artist choosenArtist = null;
        selectArtistId: Console.Write("Enter ArtistId: ");
            int artistId = InputValidation.IntegerValidation();
         
                choosenArtist = Organizer.SelectArtist(artistId);
                if (choosenArtist == null)
                {
                    Console.WriteLine("No such artist!");
                    goto selectArtistId;
                }
           



            Console.WriteLine();
            Console.WriteLine("Select Venue: ");
            Venue.ViewVenues();
            selectVenueId:  Console.Write("Enter VenueId: ");
            Venue choosenVenue = null;
            int venueId= InputValidation.IntegerValidation();
           
               
                choosenVenue= Organizer.SelectVenue(venueId);
                if (choosenVenue == null)
                {
                    goto selectVenueId;
                }
           
            string eventName = null;
            while (true)
            {
                Console.Write("Enter name of the event: ");
                eventName = InputValidation.NullValidation();
                if(String.IsNullOrEmpty(eventName))
                {
                    Console.WriteLine("Event name can't be blanked!!");
                    continue;
                }
                break;
            }
            Console.Write("Enter number of tickets: ");
            int tickets = InputValidation.IntegerValidation();
            Console.Write("Enter price per ticket: ");
            int price= InputValidation.IntegerValidation();
            
            Organizer organizerOfEvent= new Organizer();
            if (role == Role.Organizer)
            {
                organizerOfEvent = Organizer.GetOrganizer(username);
            }
            else if(role ==Role.Admin)
            {
                selectOrganizer: Console.WriteLine("Select an organizer: ");
                Organizer.ViewOrganizers();
                Console.Write("Enter organizer username: ");
                string uname = InputValidation.NullValidation();   
                organizerOfEvent = Organizer.GetOrganizer(uname);
                if (organizerOfEvent == null)
                {
                    Console.WriteLine("No such organizer!!");
                    goto selectOrganizer;
                }

            }
            int initialTick = tickets;
            var newEvent = new Event()
            {
                Id= eventIDInc,
                Name= eventName,
                organizer = organizerOfEvent,
                artist = choosenArtist,
                venue= choosenVenue,
                NumOfTicket=tickets,
                initialTickets=initialTick,
                Price=price

            };
            Event.AddEvent(newEvent);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                  Event Added Successfully!                -");
            Console.WriteLine("-------------------------------------------------------------");
            Console.ResetColor();
            if (role == Role.Admin)
            {
                AdminUI.ADMINUI(username);
            }
            else
            {
                OrganizerUI.ORGANIZERUI(username);
            }

        }

        public static void CancelEventUI(string username, Role role)
        {
            if(role== Role.Organizer)
            {
                Event.ViewEvents(username, role);
            }
            Console.Write("Select EventId: ");
            int deleteEventId = InputValidation.IntegerValidation();
            if (Event.DeleteEvent(deleteEventId))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-                Event Deleted Successfully!                -");
                Console.WriteLine("-------------------------------------------------------------");
                Console.ResetColor();
                if (role == Role.Admin)
                {
                    AdminUI.ADMINUI(username);
                }
                else
                {
                    OrganizerUI.ORGANIZERUI(username);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-                 Tickets already booked!                   -");
                Console.WriteLine("-                 Event can't be deleted!                   -");
                Console.WriteLine("-------------------------------------------------------------");
                Console.ResetColor();
                if (role == Role.Admin)
                {
                    Event.ViewEvents(username, Role.Admin);
                }
                else
                {
                    Event.ViewEvents(username, Role.Organizer);
                }
            }
            

        }
    }
}
