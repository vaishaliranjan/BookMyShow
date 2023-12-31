﻿using Newtonsoft.Json;
using Project.Models;
using Project.Controller;
using Project.Views;
using Project.DatabaseInterface;

namespace Project.Database
{
    
    public class ArtistDbHandler: DbHandler<Models.Artist>, IArtistDbHandler
    {
        private static ArtistDbHandler artistDbInstance;
        private static string _artist_path;
        public List<Models.Artist> ListOfArtists { get; set; }
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
            ListOfArtists = new List<Models.Artist>();
            _artist_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Project\Files\Artists.json";

            try
            {
                string artistFileContent = File.ReadAllText(_artist_path);
                ListOfArtists = JsonConvert.DeserializeObject<List<Models.Artist>>(artistFileContent)!;
            }
            catch(Exception ex) 
            {
                Error.UnexpectedError();
                HelperClass.LogException(ex, "An error occurred while reading the json.");
            }
        }
        public bool AddArtist(Artist artist)
        {
            if (AddEntry(artist, ListOfArtists, _artist_path))
                return true;
            return false;
        }

        public bool RemoveArtist(List<Artist> listOfArtists)
        {
            return UpdateEntry(_artist_path, listOfArtists);
        }
    }
}
