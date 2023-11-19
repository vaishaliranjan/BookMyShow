using Project.ControllerInterface;
using Project.Database;
using Project.DatabaseInterface;
using Project.Models;
using Project.Views;

namespace Project.Controller
{
    public class ArtistController: IArtistController
    {
        public IArtistDbHandler ArtistDbHandler { get;}
        public ArtistController(IArtistDbHandler artistDbHandler)
        {
            ArtistDbHandler = artistDbHandler;
        }
        public bool Add(Artist artist)
        {
            return ArtistDbHandler.AddArtist(artist);
        }
        public List<Artist> GetAll()
        {
            return ArtistDbHandler.ListOfArtists;
        }
        public Artist GetById(int id)
        {
            var Artists= ArtistDbHandler.ListOfArtists;
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
        private bool RemoveArtist(Artist choosenArtist)
        {
            var Artists = ArtistDbHandler.ListOfArtists;
            var artist = Artists.Single(a => a.ArtistId == choosenArtist.ArtistId);
            if (artist != null)
            {
                Artists.Remove(artist);
                return ArtistDbHandler.RemoveArtist(Artists);
            }
            return false;
        }
    }
}
