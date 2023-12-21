using Moq;
using Project.Controller;
using Project.ControllerInterface;
using Project.DatabaseInterface;
using Project.Enum;
using Project.Models;


namespace Controller.Tests
{
    [TestClass]
    public class AdminControllerTests
    {
        [TestMethod]
        public void GetAdmins_ReturnsAdminList()
        {
            var users = new List<User>()
            {
                new User(1,"Vaishali", "vaishali","vaishaliranjan@gmail.com", "vaishali",Role.Admin),
                new User(2,"Vaishali", "vaishali","vaishaliranjan@gmail.com", "vaishali",Role.Admin)
            };
            // Arrange
            var adminDbHandler = new Mock<IUserDbHandler>();
            IAdminController adminController = new AdminController(adminDbHandler.Object);
            adminDbHandler.Setup(admin => admin.ListOfUsers).Returns(users);

            //Act
            var admins = adminController.GetAll();

            //Assert
            Assert.IsNotNull(admins);
            Assert.AreEqual(users.Count, admins.Count);
            Assert.IsTrue(admins.TrueForAll(cust => cust.Role == Role.Admin));
        }


        [TestMethod]
        public void GetAdmins_DoesnotReturnsAdminList()
        {
            List<User> users = null;
            // Arrange
            var adminDbHandler = new Mock<IUserDbHandler>();
            IAdminController adminController = new AdminController(adminDbHandler.Object);
            adminDbHandler.Setup(admin => admin.ListOfUsers).Returns(users);

            //Act
            var admins = adminController.GetAll();

            //Assert
            Assert.IsNull(admins);
        }

        
    }
}
