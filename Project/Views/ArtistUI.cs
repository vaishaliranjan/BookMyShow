using Project.ControllerInterface;
using Project.Helpers;
using Project.ViewsInterface;

namespace Project.Views
{
    public class ArtistUI:IArtistUI
    {
        IArtistController ArtistController { get; }
        public ArtistUI(IArtistController artistController)
        {
            ArtistController = artistController;
        }
        public void ViewArtists()
        {
            var artists = ArtistController.GetAll();
            Print.ShowArtists(artists);
        }
        
       
    }
}
