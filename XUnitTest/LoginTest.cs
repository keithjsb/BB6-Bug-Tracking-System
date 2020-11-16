using Microsoft.VisualStudio.TestTools.UnitTesting;
using BB6;
using System;


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

            UserClass benAccount = new UserClass();
            benAccount.username = loginID;
            benAccount.password = password;
            benAccount.type = userType;

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

            UserClass jazAccount = new UserClass();
            jazAccount.username = loginID;
            jazAccount.password = password;
            jazAccount.type = userType;

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

            UserClass kamaliAccount = new UserClass();
            kamaliAccount.username = loginID;
            kamaliAccount.password = password;
            kamaliAccount.type = userType;

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

            UserClass keithAccount = new UserClass();
            keithAccount.username = loginID;
            keithAccount.password = password;
            keithAccount.type = userType;

            //Act


            //Assert (https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert.istrue?view=mstest-net-1.3.2) Assert functions
            Assert.IsTrue(keithAccount.validateUser()); // Returns a Bool if the 3 details exists in the database
        }
        [TestMethod]
        public void TestComment()
        {
            int bugID = 1001;
            string commentDescription = "";
            DateTime commentTimestamp = DateTime.Now;
            string commentUsername = "";
            CommentClass cc = new CommentClass();
            cc.bugID = bugID;
            cc.commentDescription = commentDescription;
            cc.commentTimestamp = commentTimestamp;
            cc.commentUsername = commentUsername;
            

            Assert.AreEqual(cc.addComment(), 0);
        }
        [TestMethod]
        public void TestSubmitBug()
        {
            string bugReporter = "";
            string title = "Unable to add new item to checkout";
            string keywords = "cart checkout check out";
            string description = "add one item to cart > go to product A via the search bar > add new item to cart via 'add to cart' > go to cart";
            DateTime date_reported = DateTime.Now;
            string category = "UI";
            string status = "New";

            BugClass bc = new BugClass();
            bc.bugReporter = bugReporter;
            bc.title = title;
            bc.keywords = keywords;
            bc.description = description;
            bc.dateReported = date_reported;
            bc.category = category;
            bc.status = status;

            Assert.AreEqual(bc.addBug(), -1);
        }
    }
}
