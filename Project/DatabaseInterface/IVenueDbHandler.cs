using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DatabaseInterface
{
    public interface IVenueDbHandler
    {
        List<Venue> ListOfVenues { get; set; }
        bool AddVenue(Venue venue);
        bool RemoveVenue(List<Venue> listOfVenues);
    }
}
