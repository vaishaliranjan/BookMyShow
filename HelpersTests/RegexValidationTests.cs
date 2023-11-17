
namespace Helpers.Tests
{
    [TestClass]
    public class RegexValidationTests
    {
        [TestMethod]
        public void RegexValidation_ValidEmailString_ValidEmail()
        {
            bool actual = true;
            bool expected = Project.Views.RegexValidation.IsValidEmail("vaishaliranjan@watchguard.in");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RegexValidation_NotValidEmailString_NotValidEmail()
        {
            bool actual = false;
            bool expected = Project.Views.RegexValidation.IsValidEmail("vaishaliranjangmail.com");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RegexValidation_ValidNameString_ValidName()
        {
            bool actual = true;
            bool expected = Project.Views.RegexValidation.IsValidName("vaishaliranjan");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RegexValidation_NotValidNameString_NotValidName()
        {
            bool actual = false;
            bool expected = Project.Views.RegexValidation.IsValidName("3vaishali");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RegexValidation_ValidUsernameString_ValidUsername()
        {
            bool actual = true;
            bool expected = Project.Views.RegexValidation.IsValidUsername("vaishaliranjan");
            Assert.AreEqual(expected, actual);
        }
        public void RegexValidation_ValidUsernameWithNumbers_ValidUsername()
        {
            bool actual = true;
            bool expected = Project.Views.RegexValidation.IsValidUsername("vaishali123");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RegexValidation_NotValidUserameString_NotValidUsername()
        {
            bool actual = false;
            bool expected = Project.Views.RegexValidation.IsValidUsername("vaishali@");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RegexValidation_NotValidUserameWithNumberFirst_NotValidUsername()
        {
            bool actual = false;
            bool expected = Project.Views.RegexValidation.IsValidUsername("3vaishali");
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void RegexValidation_ValidPasswordString_ValidPassword()
        {
            bool actual = true;
            bool expected = Project.Views.RegexValidation.IsValidPassword("vaishali");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RegexValidation_ValidPasswordStringWithNumbers_ValidPassword()
        {
            bool actual = true;
            bool expected = Project.Views.RegexValidation.IsValidPassword("vaishali45");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RegexValidation_ValidPasswordStringWithSpecialCharacters_ValidPassword()
        {
            bool actual = true;
            bool expected = Project.Views.RegexValidation.IsValidPassword("vaishali4@5");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RegexValidation_NotValidPasswordString_NotValidPassword()
        {
            bool actual = false;
            bool expected = Project.Views.RegexValidation.IsValidPassword(" vaishali");
            Assert.AreEqual(expected, actual);
        }
    }
}
