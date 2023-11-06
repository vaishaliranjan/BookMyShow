using Newtonsoft.Json;
using Project.Controller;
using Project.Models;


namespace Project.Database
{
    internal class BookingDbHandler:DbHandler<Booking>
    {
        private static BookingDbHandler? bookingDbInstance;
        private static string? _bookings_path;
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
        public bool AddBooking(Booking booking)
        {
            if (AddEntry(booking, listOfBookings, _bookings_path))
                return true;
            return false;
        }
    }
}
