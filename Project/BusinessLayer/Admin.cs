using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer
{
    public class Admin: User
    {
        public void AddArtist(string name, DateTime timing)
        {
            Artist artist = new Artist(name, timing);
            //DatabaseManager.AddNewArtist(name, timing);

        }
    }
}
