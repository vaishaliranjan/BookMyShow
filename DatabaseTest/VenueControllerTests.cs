using Moq;
using Project.Controller;
using Project.ControllerInterface;
using Project.DatabaseInterface;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Tests
{
    [TestClass]
    public class VenueControllerTests
    {
        [TestMethod]
        public void GetVenues_ReturnsVenuesList()
        {
          
            var venueList = new List<Venue>()
            {
                new Venue(1, "Delhi"),
                new Venue(2, "Delhi"),           
            };
            // Arrange
            var venueDbHandler = new Mock<IVenueDbHandler>();
            IVenueController venueController = new VenueController(venueDbHandler.Object);
            venueDbHandler.Setup(venue => venue.ListOfVenues).Returns(venueList);

            //Act
            var venues = venueController.GetAll();

            //Assert
            Assert.IsNotNull(venues);
            Assert.AreEqual(venueList.Count, venues.Count);
        }


        [TestMethod]
        public void GetVenues_DoesNotReturnsVenueList()
        {
            List<Venue> venueList = null;

            // Arrange
            var venueDbHandler = new Mock<IVenueDbHandler>();
            IVenueController venueController = new VenueController(venueDbHandler.Object);
            venueDbHandler.Setup(venue => venue.ListOfVenues).Returns(venueList);

            //Act
            var venues = venueController.GetAll();

            //Assert
            Assert.IsNull(venues);
        }



        [TestMethod]
        public void GetArtist_ById_ReturnsArtist()
        {

            var venueList = new List<Venue>()
            {
                new Venue(1, "Delhi"),
                new Venue(2, "Delhi"),
            };
            // Arrange
            var venueDbHandler = new Mock<IVenueDbHandler>();
            IVenueController venueController = new VenueController(venueDbHandler.Object);
            venueDbHandler.Setup(venue => venue.ListOfVenues).Returns(venueList);

            //Act
            var venue = venueController.GetById(1);

            //Assert
            Assert.IsInstanceOfType(venue, typeof(Venue));
            Assert.IsNotNull(venue);
        }
        [TestMethod]
        public void GetVenue_ById_DoesnotReturnVenue()
        {
            var venueList = new List<Venue>()
            {
                new Venue(1, "Delhi"),
                new Venue(2, "Delhi"),
            };
            // Arrange
            var venueDbHandler = new Mock<IVenueDbHandler>();
            IVenueController venueController = new VenueController(venueDbHandler.Object);
            venueDbHandler.Setup(venue => venue.ListOfVenues).Returns(venueList);

            //Act
            var venue = venueController.GetById(4);

            //Assert
            Assert.IsNull(venue);
        }

        [TestMethod]
        public void AddVenue_AddinVenueList()
        {
            var venue = new Venue(1, "Delhi");

            // Arrange
            var venueDbHandler = new Mock<IVenueDbHandler>();
            IVenueController venueController = new VenueController(venueDbHandler.Object);
            venueDbHandler.Setup(v => v.AddVenue(venue)).Returns(true);
            bool expected = true;
            //Act

            bool actual = venueController.Add(venue);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddArtist_DoesnotAddinArtistList()
        {
            var venue = new Venue(1, "Delhi");

            // Arrange
            var venueDbHandler = new Mock<IVenueDbHandler>();
            IVenueController venueController = new VenueController(venueDbHandler.Object);
            venueDbHandler.Setup(x => x.AddVenue(venue)).Returns(false);
            bool expected = false;
            //Act

            bool actual = venueController.Add(venue);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RemoveVenue_RemoveFromVenueList()
        {
            var venue = new Venue(1, "Delhi");
            var venueList = new List<Venue>()
            {
                new Venue(1, "Delhi"),
                new Venue(2, "Delhi"),
            };

            // Arrange
            var venueDbHandler = new Mock<IVenueDbHandler>();
            IVenueController venueController = new VenueController(venueDbHandler.Object);
            venueDbHandler.Setup(v => v.ListOfVenues).Returns(venueList);
            venueDbHandler.Setup(x => x.RemoveVenue(venueList)).Returns(true);
            bool expected = true;

            //Act
            bool actual = venueController.RemoveVenue(venue);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveVenue_DoesnotRemoveFromVenueList()
        {
            var venue = new Venue(1, "Delhi");
            var venueList = new List<Venue>()
            {
                new Venue(1, "Delhi"),
                new Venue(2, "Delhi"),
            };

            // Arrange
            var venueDbHandler = new Mock<IVenueDbHandler>();
            IVenueController venueController = new VenueController(venueDbHandler.Object);
            venueDbHandler.Setup(v => v.ListOfVenues).Returns(venueList);
            venueDbHandler.Setup(x => x.RemoveVenue(venueList)).Returns(false);
            bool expected = false;

            //Act
            bool actual = venueController.RemoveVenue(venue);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
