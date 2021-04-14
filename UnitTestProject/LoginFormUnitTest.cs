using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BCITDesktop;
using System.Windows.Forms;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class LoginFormUnitTest
    {
        public LoginFormUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// Test hasEmptyFields method in login forms for empty forms.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodHasEmptyFieldsWithEmptyFields()
        {
            //Arrange
            LoginForm loginForm = new LoginForm();
            PrivateObject loginFormObject = new PrivateObject(loginForm);

            // Act
            Boolean result = (Boolean) loginFormObject.Invoke("hasEmptyFields");

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Test hasEmptyFields method in login forms for non-empty forms.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodHasEmptyFieldsWithNonEmptyFields()
        {
            //Arrange
            LoginForm loginForm = new LoginForm();
            PrivateObject loginFormObject = new PrivateObject(loginForm);

            TextBox userLog = new System.Windows.Forms.TextBox();
            userLog.Text = "something";

            TextBox passLog = new System.Windows.Forms.TextBox();
            passLog.Text = "something";

            loginFormObject.SetFieldOrProperty("userLog", userLog);
            loginFormObject.SetFieldOrProperty("passLog", passLog);

            // Act
            Boolean result = (Boolean)loginFormObject.Invoke("hasEmptyFields");

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}
