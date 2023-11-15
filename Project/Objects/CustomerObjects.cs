using Project.Controller;
using Project.ControllerInterface;
using Project.Models;

namespace Project.Objects
{
    public class CustomerObjects 
    {
        public Customer realCustomerObject;
        public ICustomerController customerController;
        public IBookingController bookingController;
        public IEventController eventContoller;
        public CustomerObjects(Customer customer)
        {
            realCustomerObject = customer;
            bookingController = new BookingController();
            eventContoller = new EventContoller();
            customerController = new CustomerController();
        }

    }
}
