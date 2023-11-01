using Project.Controller;
using Project.Database;

namespace Project.BusinessLayer
{
    public class Artist
    {
        public int artistId;
        public string Name;
        public DateTime timing;
       
        public static int id = 6;

        public Artist(string name, DateTime timing)
        {
            this.Name = name;
            this.timing = timing;
            this.artistId = id;
            id++;
            
        }
        public static bool AddNewArtist(Artist artist)
        {     
            return ArtistDbHandler.ArtistDbInstance.AddEntry(artist);
        }

        public static void ViewArtists()
        {
            List<Artist> artists = ArtistDbHandler.ArtistDbInstance.listOfArtists;
            if (artists != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                           ARTISTS                         -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-------------------------------------------------------------");

                foreach (var artist in artists)
                {
                    Console.WriteLine("Artist Id: " + artist.artistId);
                    Console.WriteLine("Artist Name: " + artist.Name);
                    Console.WriteLine("Artist Time: " + artist.timing);
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
            else
            {
                Error.NotFound("artists");
            }
            
        }
    }
}
