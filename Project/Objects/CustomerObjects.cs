using Project.Controller;
using Project.Models;

namespace Project.Objects
{
    internal class CustomerObjects : AllUserObjects
    {
        public Customer realCustomerObject;
        public CustomerController customerController;
        public BookingController bookingController;
        public EventContoller eventContoller;
        public CustomerObjects(Customer customer)
        {
            realCustomerObject = customer;
            bookingController = new BookingController();
            eventContoller = new EventContoller();
            customerController = new CustomerController();
        }

    }
}
