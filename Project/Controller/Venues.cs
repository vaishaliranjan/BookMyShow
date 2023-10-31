

namespace Project.BusinessLayer
{
    public class Venue
    {
        public int venueId;
        public string Place;
        public static int venueIDS = 106;
        public Venue(string Place)
        {
            this.Place = Place;
            this.venueId = venueIDS++;
        }
        public static void AddNewVenue(Venue venue)
        {
            DatabaseManager.DbObject.AddVenue(venue);
        }
        public static void ViewVenues()
        {
            List<Venue> venues = null;

            venues= DatabaseManager.DbObject.ReadVenues();
            if (venues != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                            VENUES                         -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-------------------------------------------------------------");

                foreach (Venue venue in venues)
                {
                    Console.WriteLine("VenueID: " + venue.venueId);
                    Console.WriteLine("Location: " + venue.Place);
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
            Console.WriteLine("venues");
        }
    }
}
