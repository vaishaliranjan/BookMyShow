using Project.ControllerInterface;
using Moq;
using Project.Models;
using Project.Controller;

using Project.DatabaseInterface;
using Project.Enum;

namespace Controller.Tests
{
    [TestClass]
    public class CustomerControllerTests
    {
        [TestMethod]
        public void GetCustomers_ReturnsCustomerList()
        {
            var users = new List<User>()
            {
                new User(1,"Vaishali", "vaishali","vaishaliranjan@gmail.com", "vaishali",Role.Customer),
                new User(2,"Vaishali", "vaishali","vaishaliranjan@gmail.com", "vaishali",Role.Customer)
            };
            // Arrange
            var customerDbHandler= new Mock<IUserDbHandler>();
            ICustomerController customerController = new CustomerController(customerDbHandler.Object);
            customerDbHandler.Setup(customer=> customer.ListOfUsers).Returns(users);

            //Act
            var customers= customerController.GetAll();

            //Assert
            Assert.IsNotNull(customers);
            Assert.AreEqual(users.Count, customers.Count);
            Assert.IsTrue(customers.TrueForAll(cust => cust.Role == Role.Customer));
        }


        [TestMethod]
        public void GetCustomers_DoesnotReturnsCustomerList()
        {
            List<User> users = null;
            // Arrange
            var customerDbHandler = new Mock<IUserDbHandler>();
            ICustomerController customerController = new CustomerController(customerDbHandler.Object);
            customerDbHandler.Setup(customer => customer.ListOfUsers).Returns(users);

            //Act
            var customers = customerController.GetAll();

            //Assert
            Assert.IsNull(customers);
        }

        [TestMethod]
        public void GetCustomer_ByUsername_ReturnsCustomer()
        {
            var users = new List<User>()
            {
                new User(1,"Vaishali", "vaishali","vaishaliranjan@gmail.com", "vaishali",Role.Customer),
                new User(2,"Vaishali", "vaishali2","vaishaliranjan@gmail.com", "vaishali",Role.Customer)
            };
            //var expectedCustomer = new User(1, "Vaishali", "vaishali", "vaishaliranjan@gmail.com", "vaishali", Role.Customer);
            // Arrange
            var customerDbHandler = new Mock<IUserDbHandler>();
            ICustomerController customerController = new CustomerController(customerDbHandler.Object);
            customerDbHandler.Setup(customer => customer.ListOfUsers).Returns(users);

            //Act
            var realCustomer = customerController.GetByUsername("vaishali");

            //Assert
            Assert.IsInstanceOfType(realCustomer, typeof(User));
        }

        [TestMethod]
        public void GetCustomer_ByUsername_DoesnotReturnsCustomer()
        {
            var users = new List<User>()
            {
                new User(1,"Vaishali", "vaishali","vaishaliranjan@gmail.com", "vaishali",Role.Customer),
                new User(2,"Vaishali", "vaishali2","vaishaliranjan@gmail.com", "vaishali",Role.Customer)
            };
            //var expectedCustomer = new User(1, "Vaishali", "vaishali", "vaishaliranjan@gmail.com", "vaishali", Role.Customer);
            // Arrange
            var customerDbHandler = new Mock<IUserDbHandler>();
            ICustomerController customerController = new CustomerController(customerDbHandler.Object);
            customerDbHandler.Setup(customer => customer.ListOfUsers).Returns(users);

            //Act
            var customer = customerController.GetByUsername("vai");

            //Assert
            Assert.IsNull(customer);
        }




    }
}