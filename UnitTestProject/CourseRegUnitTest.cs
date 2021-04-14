using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BCITDesktop;
using System.Windows.Forms;

/// <summary>
/// Module containing unit tests for course reg.
/// Authors: Eric Dong
/// Include here date/revisions: Version 1.0, April 13th 2021.
/// </summary>
namespace UnitTestProject
{
    /// <summary>
    /// Class for testing helper methods for course reg form.
    /// Authors: Eric Dong
    /// </summary>
    [TestClass]
    public class CourseRegUnitTest
    {

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
        /// Test hasEmptyFields method in course reg form for non-empty fields.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodHasEmptyFieldsForNonEmptyFields()
        {
            //Arrange
            Student dummyStudent = new Student()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                StudentNumber = "A00000001",
                Email = "teststudent@test.test",
                Password = "TestPassword",
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };

            CourseReg courseReg = new CourseReg(dummyStudent);
            PrivateObject courseRegForm = new PrivateObject(courseReg);

            TextBox crsName = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox crsID = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox instrName = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox credits = new System.Windows.Forms.TextBox { Text = "something" };

            courseRegForm.SetFieldOrProperty("crsName", crsName);
            courseRegForm.SetFieldOrProperty("crsID", crsID);
            courseRegForm.SetFieldOrProperty("instrName", instrName);
            courseRegForm.SetFieldOrProperty("credits", credits);

            // Act
            Boolean result = (Boolean)courseRegForm.Invoke("hasEmptyFields");

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test hasEmptyFields method in course reg form for some empty fields.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodHasEmptyFieldsForSomeEmptyFields()
        {
            //Arrange
            Student dummyStudent = new Student()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                StudentNumber = "A00000001",
                Email = "teststudent@test.test",
                Password = "TestPassword",
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };

            TextBox crsName = new System.Windows.Forms.TextBox { Text = "something" };
            CourseReg courseReg = new CourseReg(dummyStudent);
            PrivateObject courseRegForm = new PrivateObject(courseReg);

            courseRegForm.SetFieldOrProperty("crsName", crsName);

            // Act
            Boolean result = (Boolean)courseRegForm.Invoke("hasEmptyFields");

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Test hasEmptyFields method in course reg form for empty fields.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodHasEmptyFieldsForEmptyFields()
        {
            //Arrange
            Student dummyStudent = new Student()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                StudentNumber = "A00000001",
                Email = "teststudent@test.test",
                Password = "TestPassword",
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };
            CourseReg courseReg = new CourseReg(dummyStudent);
            PrivateObject courseRegForm = new PrivateObject(courseReg);

            // Act
            Boolean result = (Boolean)courseRegForm.Invoke("hasEmptyFields");

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
