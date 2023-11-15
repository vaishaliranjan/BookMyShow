using Project.Models;


namespace Project.ControllerInterface
{
    public interface IVenueController : IGetAll<Venue>, IAdd<Venue>, IGetByID<Venue> { }
}
