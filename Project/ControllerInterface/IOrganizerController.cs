using Project.Models;


namespace Project.ControllerInterface
{
    public interface IOrganizerController : IGetAll<User>, IGetByUsername<User> { }
}
