using Project.Controller;
using Project.ControllerInterface;
using Project.Models;
using Project.UILayer;

namespace Project.Views
{
    public class ArtistUI
    {
        public static void ViewArtists(IArtistController artistController)
        {
            var artists = artistController.GetAll();
            ShowArtists(artists);
        }
        static void ShowArtists(List<Artist> artists)
        {
            if (artists != null)
            {
                Message.ViewArtists();
                foreach (var artist in artists)
                {
                    Console.WriteLine("Artist Id: " + artist.ArtistId);
                    Console.WriteLine("Artist Name: " + artist.Name);
                    Console.WriteLine("Artist Time: " + artist.Timing);
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
