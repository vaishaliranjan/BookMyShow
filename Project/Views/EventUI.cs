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
            Artist choosenArtist = null;
        selectArtistId: Console.Write("Enter ArtistId: ");
            int artistId;
            try
            {
                artistId = Convert.ToInt32(Console.ReadLine());
                choosenArtist = Organizer.SelectArtist(artistId);
            }
            catch
            {
                Console.WriteLine("You can entr only numerical value");
                goto selectArtistId;
            }



            Console.WriteLine();
            Console.WriteLine("Select Venue: ");
            Venue.ViewVenues();
            selectVenueId:  Console.Write("Enter VenueId: ");
            Venue choosenVenue = null;
            int venueId;
            try
            {
                venueId = Convert.ToInt32(Console.ReadLine());
                choosenVenue= Organizer.SelectVenue(venueId);
            }
            catch(Exception ex)
            {
                Console.WriteLine("You can entr only numerical value");
                goto selectVenueId;
            }
            string eventName = null;
            while (true)
            {
                Console.Write("Enter name of the event: ");
                eventName = Console.ReadLine();
                if(String.IsNullOrEmpty(eventName))
                {
                    Console.WriteLine("Event name can't be blanked!!");
                    continue;
                }
                break;
            }
            int tickets;
            numberOfTickets:  try
            {
                Console.Write("Enter number of tickets: ");
                tickets = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Number of tickets can only be integer!");
                goto numberOfTickets;
            }
            int price;
            pricePerTicket: try
            {
                Console.Write("Enter price per ticket: ");
                price= Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Price can only be integer!");
                goto pricePerTicket;
            }
             

            
            
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
        selectEventId: Console.Write("Select EventId: ");
            int deleteEventId;
            try
            {
                deleteEventId = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("You can only enter a numerical value!");
                goto selectEventId;
            }
            
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
