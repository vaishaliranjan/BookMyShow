using Project.Database;
using Project.Models;


namespace Project.Controller
{
    public class ArtistController
    {
        public bool AddNewArtist(Artist artist)
        {
            return ArtistDbHandler.ArtistDbInstance.AddArtist(artist);
        }
        public List<Artist> ViewArtists()
        {
            return ArtistDbHandler.ArtistDbInstance.listOfArtists;
        }
        public Artist SelectArtist(int id)
        {
            Artist choosenArtist = null;
            try
            {
                choosenArtist = ArtistDbHandler.ArtistDbInstance.listOfArtists.Single(a => a.artistId == id);
                ArtistDbHandler.ArtistDbInstance.RemoveArtist(choosenArtist);
                return choosenArtist;
            }
            catch (Exception ex)
            {
                return choosenArtist;
            }
        }
    }
}
