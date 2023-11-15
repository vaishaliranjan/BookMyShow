using Project.Models;


namespace Project.ControllerInterface
{
    public interface ICustomerController : IGetAll<Customer>, IGetByUsername<Customer> { }
}
