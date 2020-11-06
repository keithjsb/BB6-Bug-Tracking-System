using Microsoft.VisualStudio.TestTools.UnitTesting;
using BB6;


namespace Testing
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void TestBugReporterLoginBugReporter()
        {
            //Arrange
            string loginID = "benton";
            string password = "benton123";
            string userType = "BR";

            UserClass benAccount = new UserClass(loginID, password, userType);

            //Act


            //Assert (https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert.istrue?view=mstest-net-1.3.2) Assert functions
            Assert.IsTrue(benAccount.validateUser()); // Returns a Bool if the 3 details exists in the database
        }

        [TestMethod]
        public void TestBugReporterLoginTriager()
        {
            //Arrange
            string loginID = "Jazryll";
            string password = "jaz123";
            string userType = "T";

            UserClass jazAccount = new UserClass(loginID, password, userType);

            //Act


            //Assert (https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert.istrue?view=mstest-net-1.3.2) Assert functions
            Assert.IsTrue(jazAccount.validateUser()); // Returns a Bool if the 3 details exists in the database
        }

        [TestMethod]
        public void TestBugReporterLoginReviewer()
        {
            //Arrange
            string loginID = "Kamali";
            string password = "kamali123";
            string userType = "R";

            UserClass kamaliAccount = new UserClass(loginID, password, userType);

            //Act


            //Assert (https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert.istrue?view=mstest-net-1.3.2) Assert functions
            Assert.IsTrue(kamaliAccount.validateUser()); // Returns a Bool if the 3 details exists in the database
        }

        [TestMethod]
        public void TestBugReporterLoginDeveloper()
        {
            //Arrange
            string loginID = "Keith";
            string password = "keith123";
            string userType = "D";

            UserClass keithAccount = new UserClass(loginID, password, userType);

            //Act


            //Assert (https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert.istrue?view=mstest-net-1.3.2) Assert functions
            Assert.IsTrue(keithAccount.validateUser()); // Returns a Bool if the 3 details exists in the database
        }
    }
}
