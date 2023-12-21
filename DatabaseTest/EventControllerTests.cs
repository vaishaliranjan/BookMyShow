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
    public class EventControllerTests
    {
        [TestMethod]
        public void GetEvents_ByUsername_ReturnsEvent()
        {
            var eventList = new List<Event>()
            {
               new Event(1,"Bool BOOL","vaishali",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000),
               new Event(2,"Sunshine","ritika",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000)
            };
            // Arrange
            var eventDbHandler = new Mock<IEventDbHandler>();
            IEventController eventController = new EventContoller(eventDbHandler.Object);
            eventDbHandler.Setup(e => e.ListOfEvents).Returns(eventList);

            //Act
            var events = eventController.GetOrganizerEvents("ritika");

            //Assert
            Assert.IsNotNull(events);
        }

        [TestMethod]
        public void GetEvents_ByUsername_DoesnotReturnEvent()
        {
            var eventList = new List<Event>()
            {
               new Event(1,"Bool BOOL","vaishali",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000),
               new Event(2,"Sunshine","ritika",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000)
            };
            // Arrange
            var eventDbHandler = new Mock<IEventDbHandler>();
            IEventController eventController = new EventContoller(eventDbHandler.Object);
            eventDbHandler.Setup(e => e.ListOfEvents).Returns(eventList);

            //Act
            var events = eventController.GetOrganizerEvents("vvv");

            //Assert
            Assert.IsInstanceOfType(events[0],typeof(Event));
        }

        [TestMethod]
        public void DecrementTicket_SuccessfullyDecremented()
        {
            var eventList = new List<Event>()
            {
               new Event(1,"Bool BOOL","vaishali",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000),
               new Event(2,"Sunshine","ritika",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000)
            };

            // Arrange
            var eventDbHandler = new Mock<IEventDbHandler>();
            IEventController eventController = new EventContoller(eventDbHandler.Object);
            eventDbHandler.Setup(e => e.ListOfEvents).Returns(eventList);
            eventDbHandler.Setup(e => e.DecTicketToDB(eventList)).Returns(true);

            //Act
            eventController.DecrementTicket(eventList[0], 4);

            //Assert
            Assert.AreEqual(196, eventList[0].NumOfTicket);
        }


        [TestMethod]
        public void RemoveEvent_RemoveFromEventList()
        {
            var eventRemove = new Event(1, "Bool BOOL", "vaishali", new Artist(1, "Arijit SIngh", new DateTime(2023, 11, 30)), new Venue(1, "GIP"), 200, 200, 4000);
            var eventList = new List<Event>()
            {
               new Event(1,"Bool BOOL","vaishali",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000),
               new Event(2,"Sunshine","ritika",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000)
            };

            // Arrange
            var eventDbHandler = new Mock<IEventDbHandler>();
            IEventController eventController = new EventContoller(eventDbHandler.Object);
            eventDbHandler.Setup(e => e.ListOfEvents).Returns(eventList);
            eventDbHandler.Setup(e => e.RemoveEvent(eventList)).Returns(true);
            bool expected = true;
            //Act
            bool actual = eventController.Delete(1);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveEvent_DoesNotRemoveFromEventList()
        {
            var eventRemove = new Event(1, "Bool BOOL", "vaishali", new Artist(1, "Arijit SIngh", new DateTime(2023, 11, 30)), new Venue(1, "GIP"), 200, 200, 4000);
            var eventList = new List<Event>()
            {
               new Event(1,"Bool BOOL","vaishali",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000),
               new Event(2,"Sunshine","ritika",new Artist(1,"Arijit SIngh", new DateTime(2023,11,30)),new Venue(1,"GIP"),200,200,4000)
            };

            // Arrange
            var eventDbHandler = new Mock<IEventDbHandler>();
            IEventController eventController = new EventContoller(eventDbHandler.Object);
            eventDbHandler.Setup(e => e.ListOfEvents).Returns(eventList);
            eventDbHandler.Setup(e => e.RemoveEvent(eventList)).Returns(false);
            bool expected = false;
            //Act
            bool actual = eventController.Delete(1);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
