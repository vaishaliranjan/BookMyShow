using Project.Models;


namespace Project.ControllerInterface
{
    public interface IBookingController : IGetAll<Booking>, IBook
    {
        List<Booking> GetCustomerBookings(string username);
    }
}
