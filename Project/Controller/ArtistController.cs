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
            Artist choosenArtist = null;
            try
            {
                choosenArtist = ArtistDbHandler.ArtistDbInstance.ListOfArtists.Single(a => a.ArtistId == id);
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
            var listOfArtists = ArtistDbHandler.ArtistDbInstance.ListOfArtists;
            var artist = listOfArtists.Single(a => a.ArtistId == choosenArtist.ArtistId);
            if (artist != null)
            {
                listOfArtists.Remove(artist);
                return ArtistDbHandler.ArtistDbInstance.RemoveArtist(listOfArtists);
            }
            return false;
        }
    }
}
