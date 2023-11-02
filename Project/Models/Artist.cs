using Project.Controller;
using Project.Database;

namespace Project.Models
{
    public class Artist
    {
        public int artistId;
        public string Name;
        public DateTime timing;

        public static int id = 6;

        public Artist(string name, DateTime timing)
        {
            Name = name;
            this.timing = timing;
            artistId = id;
            id++;

        }
        
    }
}
