using Newtonsoft.Json;
using Project.Controller;
using Project.DatabaseInterface;
using Project.Models;
using Project.Views;

namespace Project.Database
{
    
    public class BookingDbHandler:DbHandler<Booking>, IBookingDbHandler
    {
        private static BookingDbHandler bookingDbInstance;
        private static string _bookings_path;
        public List<Booking> ListOfBookings { get; set; }
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
            ListOfBookings = new List<Booking>();
            _bookings_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Project\Files\Bookings.json";

            try
            {
                string bookingFileContent = File.ReadAllText(_bookings_path);
                ListOfBookings = JsonConvert.DeserializeObject<List<Booking>>(bookingFileContent)!;
            }
            catch(Exception ex) 
            {
                Error.UnexpectedError();
                HelperClass.LogException(ex, "An error occurred while reading the json.");
            }
        }
        public bool AddBooking(Booking booking)
        {
            if (AddEntry(booking, ListOfBookings, _bookings_path))
                return true;
            return false;
        }
    }
}
