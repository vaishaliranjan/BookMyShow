using Project.Models;


namespace Project.ControllerInterface
{
    public interface IArtistController : IGetAll<Artist>, IAdd<Artist>, IGetByID<Artist> { }
}
