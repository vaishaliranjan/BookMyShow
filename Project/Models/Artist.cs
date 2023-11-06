using Project.Controller;
using Project.Database;

namespace Project.Models
{
    public class Artist
    {
        public int artistId;
        public string Name;
        public DateTime timing;

        public static int id = ArtistDbHandler.ArtistDbInstance.listOfArtists[ArtistDbHandler.ArtistDbInstance.listOfArtists.Count-1].artistId;

        public Artist(int artistId,string name, DateTime timing)
        {
            
            Name = name;
            this.timing = timing;
            this.artistId = artistId;


        }
        
    }
}
