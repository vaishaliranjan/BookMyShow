using Project.Models;


namespace Project.ControllerInterface
{
    public interface IOrganizerController : IGetAll<Organizer>, IGetByUsername<Organizer> { }
}
