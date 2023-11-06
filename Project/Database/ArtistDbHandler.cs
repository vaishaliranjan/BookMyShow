using Newtonsoft.Json;
using Project.Models;
using Project.Controller;

namespace Project.Database
{
    internal class ArtistDbHandler: DbHandler<Artist>
    {
        private static ArtistDbHandler? artistDbInstance;
        private static string? _artist_path;
        public List<Artist> listOfArtists { get; set; }
        public static ArtistDbHandler ArtistDbInstance
        {
            get
            {
                if (artistDbInstance == null)
                {
                    artistDbInstance = new ArtistDbHandler();
                }
                return artistDbInstance;
            }
        }

        private ArtistDbHandler()
        {
            listOfArtists = new List<Artist>();
            _artist_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Artists.json";

            try
            {
                string artistFileContent = File.ReadAllText(_artist_path);
                listOfArtists = JsonConvert.DeserializeObject<List<Artist>>(artistFileContent)!;
            }
            catch
            {
                Error.UnexpectedError();
            }
        }
        public bool AddArtist(Artist artist)
        {
            if (AddEntry(artist, listOfArtists, _artist_path))
                return true;
            return false;
        }

        public bool RemoveArtist(Artist deleteArtist)
        {
            var artist = listOfArtists.Single(a => a.artistId == deleteArtist.artistId);
            if (artist != null)
            {
                listOfArtists.Remove(artist);
                UpdateEntry(_artist_path, listOfArtists);
                return true;
            }
            return false;
        }
    }
}
