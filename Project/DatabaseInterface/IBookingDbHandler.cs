using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DatabaseInterface
{
    public interface IBookingDbHandler
    {
        List<Booking> ListOfBookings { get; set; }
        bool AddBooking(Booking booking);
    }
}
