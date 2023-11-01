using Newtonsoft.Json;
using Project.BusinessLayer;
using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database
{
    internal class BookingDbHandler:DbHandler
    {
        private static BookingDbHandler bookingDbInstance;
        private static string _bookings_path;
        public List<Booking> listOfBookings { get; set; }
        public static BookingDbHandler BookingDbInstance
        {
            get
            {
                if (bookingDbInstance == null)
                {
                    bookingDbInstance = new BookingDbHandler();
                }
                return bookingDbInstance;
            }
        }

        private BookingDbHandler()
        {
            listOfBookings = new List<Booking>();
            _bookings_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Bookings.json";

            try
            {
                string bookingFileContent = File.ReadAllText(_bookings_path);
                listOfBookings = JsonConvert.DeserializeObject<List<Booking>>(bookingFileContent)!;
            }
            catch
            {
                Error.UnexpectedError();
            }
        }
        public override bool AddEntry(object obj)
        {
            if (obj is Booking)
            {
                listOfBookings.Add((Booking)obj);
                if (UpdateEntry<Booking>(_bookings_path, listOfBookings))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
