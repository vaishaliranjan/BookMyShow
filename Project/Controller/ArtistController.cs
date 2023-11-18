using Project.ControllerInterface;
using Project.Database;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class ArtistController: IArtistController
    {
        
        public bool Add(Artist artist)
        {
            return ArtistDbHandler.ArtistDbInstance.AddArtist(artist);
        }
        public List<Artist> GetAll()
        {
            return ArtistDbHandler.ArtistDbInstance.ListOfArtists;
        }
        public Artist GetById(int id)
        {
            var Artists= ArtistDbHandler.ArtistDbInstance.ListOfArtists;
            Artist choosenArtist = null;
            try
            {
                choosenArtist = Artists.Single(a => a.ArtistId == id);
                RemoveArtist(choosenArtist);
                return choosenArtist;
            }
            catch (Exception ex)
            {
                HelperClass.LogException(ex, "More than one artist with same id.");
                return choosenArtist;
            }
        }
        private static bool RemoveArtist(Artist choosenArtist)
        {
            var Artists = ArtistDbHandler.ArtistDbInstance.ListOfArtists;
            var artist = Artists.Single(a => a.ArtistId == choosenArtist.ArtistId);
            if (artist != null)
            {
                Artists.Remove(artist);
                return ArtistDbHandler.ArtistDbInstance.RemoveArtist(Artists);
            }
            return false;
        }
    }
}
