using Project.Database;

namespace Project.Models
{
    public class Artist
    {
        public int ArtistId;
        public string Name;
        public DateTime Timing;
        public static int ArtistIdInc = ArtistDbHandler.ArtistDbInstance.ListOfArtists[ArtistDbHandler.ArtistDbInstance.ListOfArtists.Count-1].ArtistId;

        public Artist(int artistId,string name, DateTime timing)
        {
            
            Name = name;
            Timing = timing;
            ArtistId = artistId;
        }
        
    }
}
