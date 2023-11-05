using Project.Controller;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
