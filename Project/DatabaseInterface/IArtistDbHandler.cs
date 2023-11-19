using Project.Models;


namespace Project.DatabaseInterface
{
    public interface IArtistDbHandler
    {
        List<Artist> ListOfArtists { get; set; }
        bool AddArtist(Artist artist);
        bool RemoveArtist(List<Artist> listOfArtists);

    }
}
