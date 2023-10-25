using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer
{
    public class Artist
    {
        public int artistId;
        public string Name;
        public DateTime timing;
       
        public static int id = 5;

        public Artist(string name, DateTime timing)
        {
            this.Name = name;
            this.timing = timing;
            this.artistId = id;
            id++;
        }

        public static void ViewArtists()
        {
            var artists = DatabaseManager.ReadArtists();
            foreach (var artist in artists)
            {
                Console.WriteLine("Artist Name: "+ artist.Name);
                Console.WriteLine("Artist Time: "+ artist.timing);
                Console.WriteLine();
            }
        }
    }
}
