using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewsInterface
{
    public interface ICustomerView
    {
        void ViewBookings(User customer);
        void ViewEvents(User customer);
    }
}
