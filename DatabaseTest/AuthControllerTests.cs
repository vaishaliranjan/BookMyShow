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
    public class AuthControllerTests
    {
        [TestMethod]
        public void Login_SuccessFullLogin()
        {
            var users = new List<User>()
            {
                new User(1,"Vaishali", "vaishali1","vaishaliranjan@gmail.com", "vaishali",Role.Admin),
                new User(2,"Vaishali", "vaishali2","vaishaliranjan@gmail.com", "vaishali",Role.Admin)
            };
            var userDbHandler = new Mock<IUserDbHandler>(); 
            IAuthController authController = new AuthController(userDbHandler.Object);

            //Arrange
            userDbHandler.Setup(user => user.ListOfUsers).Returns(users);

            //Act
            var user = authController.Login("vaishali1", "vaishali");
            Assert.IsNotNull(user);
            Assert.IsInstanceOfType(user, typeof(User));    
        }


        [TestMethod]
        public void Login_UnsuccessFullLogin()
        {
            var users = new List<User>()
            {
                new User(1,"Vaishali", "vaishali1","vaishaliranjan@gmail.com", "vaishali",Role.Admin),
                new User(2,"Vaishali", "vaishali2","vaishaliranjan@gmail.com", "vaishali",Role.Admin)
            };
            var userDbHandler = new Mock<IUserDbHandler>();
            IAuthController authController = new AuthController(userDbHandler.Object);

            //Arrange
            userDbHandler.Setup(user => user.ListOfUsers).Returns(users);

            //Act
            var user = authController.Login("vaishali", "vaishali");
            Assert.IsNull(user);
        }

        [TestMethod]
        public void Register_SuccessfullRegistration()
        {
            var user = new User(1, "Vaishali", "vaishali1", "vaishaliranjan@gmail.com", "vaishali", Role.Admin);
            var userDbHandler = new Mock<IUserDbHandler>();
            IAuthController authController = new AuthController(userDbHandler.Object);

            userDbHandler.Setup(u => u.AddUser(user)).Returns(true);

            var result = authController.Register(user, Role.Admin);
            Assert.IsTrue(result);  
        }

        [TestMethod]
        public void Register_UnsuccessfullRegistration()
        {
            var user = new User(1, "Vaishali", "vaishali1", "vaishaliranjan@gmail.com", "vaishali", Role.Admin);
            var userDbHandler = new Mock<IUserDbHandler>();
            IAuthController authController = new AuthController(userDbHandler.Object);

            userDbHandler.Setup(u => u.AddUser(user)).Returns(false);

            var result = authController.Register(user, Role.Admin);
            Assert.IsFalse(result);
        }

        public void ValidateUser_UserNotExists()
        {
            var users = new List<User>()
            {
                new User(1,"Vaishali", "vaishali1","vaishaliranjan@gmail.com", "vaishali",Role.Admin),
                new User(2,"Vaishali", "vaishali2","vaishaliranjan@gmail.com", "vaishali",Role.Admin)
            };
            var userDbHandler = new Mock<IUserDbHandler>();
            IAuthController authController = new AuthController(userDbHandler.Object);

            userDbHandler.Setup(user => user.ListOfUsers).Returns(users);

            var result = authController.ValidateUser("vaishali1");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateUser_UserExists()
        {
            var users = new List<User>()
            {
                new User(1,"Vaishali", "vaishali1","vaishaliranjan@gmail.com", "vaishali",Role.Admin),
                new User(2,"Vaishali", "vaishali2","vaishaliranjan@gmail.com", "vaishali",Role.Admin)
            };
            var userDbHandler = new Mock<IUserDbHandler>();
            IAuthController authController = new AuthController(userDbHandler.Object);

            userDbHandler.Setup(user => user.ListOfUsers).Returns(users);

            var result = authController.ValidateUser("vaishali");
            Assert.IsTrue(result);
        }
    }
}
