using Moq;
using Project.Controller;
using Project.ControllerInterface;
using Project.DatabaseInterface;
using Project.Enum;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Tests
{
    [TestClass]
    public class BookingControllerTests
    {
        [TestMethod]
        public void GetBookings_ReturnsBookingList()
        {
            var bookingList = new List<Booking>()
            {
                new Booking(1,new Event(1,"Bool BOOL","vaishali",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000),"ritika",2,8000)
            };
            // Arrange
            var bookingDbHandler = new Mock<IBookingDbHandler>();
            IBookingController bookingController = new BookingController(bookingDbHandler.Object);
            bookingDbHandler.Setup(booking => booking.ListOfBookings).Returns(bookingList);

            //Act
            var bookings = bookingController.GetAll();

            //Assert
            Assert.IsNotNull(bookings);
            Assert.AreEqual(bookingList.Count, bookings.Count);
        }


        [TestMethod]
        public void GetBookings_DoesnotReturnsBookingList()
        {
            List<Booking> bookingList = null;
            // Arrange
            var bookingDbHandler = new Mock<IBookingDbHandler>();
            IBookingController bookingController = new BookingController(bookingDbHandler.Object);
            bookingDbHandler.Setup(booking => booking.ListOfBookings).Returns(bookingList);

            //Act
            var bookings = bookingController.GetAll();

            //Assert
            Assert.IsNull(bookings);
        }



        [TestMethod]
        public void GetBookings_ByUsername_ReturnsBookings()
        {
            var bookingList = new List<Booking>()
            {
                new Booking(1,new Event(1,"Bool BOOL","vaishali",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000),"ritika",2,8000),
                new Booking(2,new Event(1,"Bool BOOL","vaishali",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000),"tisha",2,8000)
            };
            // Arrange
            var bookingDbHandler = new Mock<IBookingDbHandler>();
            IBookingController bookingController = new BookingController(bookingDbHandler.Object);
            bookingDbHandler.Setup(booking => booking.ListOfBookings).Returns(bookingList);

            //Act
            var bookings = bookingController.GetCustomerBookings("ritika");

            //Assert
            Assert.IsNotNull(bookings);
        }

        [TestMethod]
        public void GetBookings_ByUsername_DoesnotReturnsBookings()
        {
            var bookingList = new List<Booking>()
            {
                new Booking(1,new Event(1,"Bool BOOL","vaishali",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000),"ritika",2,8000),
                new Booking(2,new Event(1,"Bool BOOL","vaishali",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000),"tisha",2,8000)
            };
            // Arrange
            var bookingDbHandler = new Mock<IBookingDbHandler>();
            IBookingController bookingController = new BookingController(bookingDbHandler.Object);
            bookingDbHandler.Setup(booking => booking.ListOfBookings).Returns(bookingList);

            //Act
            var bookings = bookingController.GetCustomerBookings("ritika2");

            //Assert
            Assert.IsNull(bookings);
        }


        [TestMethod]
        public void AddBooking_SuccessfullBooking()
        {
            var booking = new Booking(1, new Event(1, "Bool BOOL", "vaishali", new Artist(1, "Arijit SIngh", new DateTime(2023, 11, 30)), new Venue(1, "GIP"), 200, 200, 4000), "ritika", 2, 8000);
            var bookingDbHandler = new Mock<IBookingDbHandler>();
            IBookingController bookingController = new BookingController(bookingDbHandler.Object);

            bookingDbHandler.Setup(b => b.AddBooking(booking)).Returns(true);

            var result = bookingController.BookEvent(booking);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddBooking_UnsuccessfullBooking()
        {
            var booking = new Booking(1, new Event(1, "Bool BOOL", "vaishali", new Artist(1, "Arijit SIngh", new DateTime(2023, 11, 30)), new Venue(1, "GIP"), 200, 200, 4000), "ritika", 2, 8000);
            var bookingDbHandler = new Mock<IBookingDbHandler>();
            IBookingController bookingController = new BookingController(bookingDbHandler.Object);

            bookingDbHandler.Setup(b => b.AddBooking(booking)).Returns(false);

            var result = bookingController.BookEvent(booking);
            Assert.IsFalse(result);
        }
    }
}
