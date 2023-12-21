using Project.Models;


namespace Project.ControllerInterface
{
    public interface ICustomerController : IGetAll<User>, IGetByUsername<User> { }
}
