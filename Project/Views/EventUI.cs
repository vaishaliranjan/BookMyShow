using Project.BusinessLayer;
using Project.UILayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views
{
    internal class EventUI
    {
        public static int eventIDInc = 105;
        public static void CreateEventUI(string username, Role role)
        {
            Console.WriteLine();
            Console.WriteLine("Select Artist: ");
            Artist.ViewArtists();
            Console.Write("Enter ArtistId: ");
            int artistId = Convert.ToInt32(Console.ReadLine());
            Artist choosenArtist = Organizer.SelectArtist(artistId);

            Console.WriteLine();
            Console.WriteLine("Select Venue: ");
            Venue.ViewVenues();
            Console.Write("Enter VenueId: ");
            int venueId = Convert.ToInt32(Console.ReadLine());
            Venue choosenVenue = Organizer.SelectVenue(venueId);


            Console.Write("Enter name of the event: ");
            string eventName = Console.ReadLine();

            Console.Write("Enter number of tickets: ");
            int tickets = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter price per ticket: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Organizer organizerOfEvent= new Organizer();
            if (role == Role.Organizer)
            {
                organizerOfEvent = Organizer.GetOrganizer(username);
            }
            else if(role ==Role.Admin)
            {
                Console.WriteLine("Select an organizer: ");
                Organizer.ViewOrganizers();
                Console.Write("Enter organizer username: ");
                string uname =Console.ReadLine();          
                organizerOfEvent = Organizer.GetOrganizer(uname);

            }
            var newEvent = new Event()
            {
                Id= eventIDInc,
                Name= eventName,
                organizer = organizerOfEvent,
                artist = choosenArtist,
                venue= choosenVenue,
                NumOfTicket=tickets,
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
            int deleteEventId = Convert.ToInt32(Console.ReadLine());
            Event.DeleteEvent(deleteEventId);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("-                Event Deleted Successfully!                -");
            Console.WriteLine("-------------------------------------------------------------");
            Console.ResetColor();
            if(role == Role.Admin)
            {
                AdminUI.ADMINUI(username);
            }
            else
            {
                OrganizerUI.ORGANIZERUI(username);
            }
            

        }
    }
}
