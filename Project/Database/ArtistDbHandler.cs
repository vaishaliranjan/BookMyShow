using Newtonsoft.Json;
using Project.BusinessLayer;
using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database
{
    internal class ArtistDbHandler: DbHandler
    {
        private static ArtistDbHandler artistDbInstance;
        private static string _artist_path;
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
        public override bool AddEntry(object obj)
        {
            if (obj is Artist)
            {
                listOfArtists.Add((Artist)obj);
                if (UpdateEntry<Artist>(_artist_path, listOfArtists))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool RemoveArtist(Artist deleteArtist)
        { 
            foreach (var artist in listOfArtists)
            {
                if (artist.artistId.Equals(deleteArtist.artistId))
                {
                    listOfArtists.Remove(artist);
                    UpdateEntry<Artist>(_artist_path, listOfArtists);
                    return true;
                }
               
            }
            return false;
        }
    }
}
