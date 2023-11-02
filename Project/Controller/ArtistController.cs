using Project.Database;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controller
{
    internal class ArtistController
    {
        public static bool AddNewArtist(Artist artist)
        {
            return ArtistDbHandler.ArtistDbInstance.AddArtist(artist);
        }

        public void ViewArtists()
        {
            List<Artist> artists = ArtistDbHandler.ArtistDbInstance.listOfArtists;
            if (artists != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                           ARTISTS                         -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-                                                           -");
                Console.WriteLine("-------------------------------------------------------------");

                foreach (var artist in artists)
                {
                    Console.WriteLine("Artist Id: " + artist.artistId);
                    Console.WriteLine("Artist Name: " + artist.Name);
                    Console.WriteLine("Artist Time: " + artist.timing);
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
            else
            {
                Error.NotFound("artists");
            }

        }
    }
}
