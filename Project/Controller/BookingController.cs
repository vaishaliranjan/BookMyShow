using Project.Database;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controller
{
    internal class BookingController
    {
        public static void BookEvent(Booking booking)
        {
            BookingDbHandler.BookingDbInstance.AddEntry(booking);
           EventContoller .DecrementTicket(booking.bookedEvent, booking.numOfTickets);
        }

        public static void ViewBookings(string username, Role role)
        {
            List<Booking> bookings = BookingDbHandler.BookingDbInstance.listOfBookings;
            if (bookings != null)
            {
                if (role == Role.Admin)
                {
                    showBookings(bookings);
                }
                else
                {
                    var customerBooking = bookings.FindAll(b => b.customer.Username == username);
                    showBookings(customerBooking);
                }
                void showBookings(List<Booking> bookings)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("-                                                           -");
                    Console.WriteLine("-                                                           -");
                    Console.WriteLine("-                         Bookings                          -");
                    Console.WriteLine("-                                                           -");
                    Console.WriteLine("-                                                           -");
                    Console.WriteLine("-------------------------------------------------------------");

                    foreach (var booking in bookings)
                    {

                        Console.WriteLine();
                        Console.WriteLine("Customer Name: " + booking.customer.Name);
                        Console.WriteLine("Event Name: " + booking.bookedEvent.Name);
                        Console.WriteLine("Artist: " + booking.bookedEvent.artist.Name);
                        Console.WriteLine("Venue: " + booking.bookedEvent.venue.Place);
                        Console.WriteLine("Date: " + booking.bookedEvent.artist.timing);
                        Console.WriteLine("Number of Tickets: " + booking.numOfTickets);
                        Console.WriteLine("Price: " + booking.totalPrice);
                        Console.WriteLine();

                    }
                    Console.ResetColor();
                }
            }
            else
            {
                Error.NotFound("bookings");
            }
        }
    }
}
