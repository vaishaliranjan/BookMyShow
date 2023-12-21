using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewsInterface
{
    public interface IAdminAdd
    {
        void AddNewEvent(User admin);
        void AddNewBooking(User admin);
        void AddNewArtist(User admin);
        void AddNewVenue(User admin);
    }
}
