using Project.Controller;


namespace Project.Views
{
    public class ArtistUI
    {
        public static void ViewArtistsUI(ArtistController artistController)
        {
            var artists = artistController.ViewArtists();
            if (artists != null)
            {
                Message.ViewArtists();

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
