using Moq;
using Project.Controller;
using Project.ControllerInterface;
using Project.DatabaseInterface;
using Project.Enum;
using Project.Models;


namespace Controller.Tests
{
    [TestClass]
    public class OrganizerControllerTests
    {
        [TestMethod]
        public void GetOrganizer_ReturnsOrganizerList()
        {
            var users = new List<User>()
            {
                new User(1,"Vaishali", "vaishali","vaishaliranjan@gmail.com", "vaishali",Role.Organizer),
                new User(2,"Vaishali", "vaishali","vaishaliranjan@gmail.com", "vaishali",Role.Organizer)
            };
            // Arrange
            var organizerDbHandler = new Mock<IUserDbHandler>();
            IOrganizerController organizerController = new OrganizerController(organizerDbHandler.Object);
            organizerDbHandler.Setup(organizer => organizer.ListOfUsers).Returns(users);

            //Act
            var organizers = organizerController.GetAll();

            //Assert
            Assert.IsNotNull(organizers);
            Assert.AreEqual(users.Count, organizers.Count);
            Assert.IsTrue(organizers.TrueForAll(cust => cust.Role == Role.Organizer));
        }


        [TestMethod]
        public void GetOrganizers_DoesnotReturnsOrganizerList()
        {
            List<User> users = null;
            // Arrange
            var organizerDbHandler = new Mock<IUserDbHandler>();
            IOrganizerController organizerController = new OrganizerController(organizerDbHandler.Object);
            organizerDbHandler.Setup(organizer => organizer.ListOfUsers).Returns(users);

            //Act
            var organizers = organizerController.GetAll();

            //Assert
            Assert.IsNull(organizers);
        }

        [TestMethod]
        public void GetOrganizer_ByUsername_ReturnsOrganizer()
        {
            var users = new List<User>()
            {
                new User(1,"Vaishali", "vaishali","vaishaliranjan@gmail.com", "vaishali",Role.Organizer),
                new User(2,"Vaishali", "vaishali2","vaishaliranjan@gmail.com", "vaishali",Role.Organizer)
            };
            // Arrange
            var organizerDbHandler = new Mock<IUserDbHandler>();
            IOrganizerController organizerController = new OrganizerController(organizerDbHandler.Object);
            organizerDbHandler.Setup(organizer => organizer.ListOfUsers).Returns(users);

            //Act
            var organizer = organizerController.GetByUsername("vaishali");

            //Assert
            Assert.IsNotNull(organizer);
            Assert.IsInstanceOfType(organizer, typeof(User));
        }

        [TestMethod]
        public void GetOrganizer_ByUsername_DoesnotReturnsOrganizer()
        {
            var users = new List<User>()
            {
                new User(1,"Vaishali", "vaishali","vaishaliranjan@gmail.com", "vaishali",Role.Organizer),
                new User(2,"Vaishali", "vaishali2","vaishaliranjan@gmail.com", "vaishali",Role.Organizer)
            };
            // Arrange
            var organizerDbHandler = new Mock<IUserDbHandler>();
            IOrganizerController organizerController = new OrganizerController(organizerDbHandler.Object);
            organizerDbHandler.Setup(organizer => organizer.ListOfUsers).Returns(users);

            //Act
            var organizer = organizerController.GetByUsername("vaish");

            //Assert
            Assert.IsNull(organizer);
           
        }
    }
}
