using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BCITDesktop;
using System.Windows.Forms;
/// <summary>
/// Module containing unit tests for userDataBaseSettingsUnitTest form helper methods.
/// Authors: Eric Dong
/// Include here date/revisions: Version 1.0, April 13th 2021.
/// </summary>
namespace UnitTestProject
{
    /// <summary>
    /// Unit tests for UserDataBaseSettings form.
    /// Author: Eric Dong
    /// </summary>
    [TestClass]
    public class UserDataBaseSettingsUnitTest
    {
        /// <summary>
        /// Unit tests for has empty fields, for state where the form has no empty fields.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodHasEmptyFieldsForNoEmptyFields()
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

            HomeForm homeref = new HomeForm(dummyStudent);
            userDataBaseSettings userDataBaseSettings = new userDataBaseSettings(dummyStudent, homeref);
            PrivateObject userDataBaseSettingsFormObject = new PrivateObject(userDataBaseSettings);

            TextBox firstName = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox Lastname = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox email = new System.Windows.Forms.TextBox { Text = "something" };

            ComboBox gender = new System.Windows.Forms.ComboBox { Text = "something" };

            TextBox phone = new System.Windows.Forms.TextBox { Text = "something" };

            DateTimePicker dobSet = new DateTimePicker();
            dobSet.Value = DateTime.Parse("2021-04-12T00:00:00-07:00");
            dobSet.Text = "2021-04-12T00:00:00-07:00";

            userDataBaseSettingsFormObject.SetFieldOrProperty("firstNameSet", firstName);
            userDataBaseSettingsFormObject.SetFieldOrProperty("lastNameSet", Lastname);
            userDataBaseSettingsFormObject.SetFieldOrProperty("emailSet", email);
            userDataBaseSettingsFormObject.SetFieldOrProperty("genderSet", gender);
            userDataBaseSettingsFormObject.SetFieldOrProperty("phoneSet", phone);
            userDataBaseSettingsFormObject.SetFieldOrProperty("dobSet", dobSet);

            // Act
            Boolean result = (Boolean)userDataBaseSettingsFormObject.Invoke("hasEmptyFields");

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Unit tests for has empty fields, for state where the form has some empty fields.
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

            HomeForm homeref = new HomeForm(dummyStudent);
            userDataBaseSettings userDataBaseSettings = new userDataBaseSettings(dummyStudent, homeref);
            PrivateObject userDataBaseSettingsFormObject = new PrivateObject(userDataBaseSettings);

            TextBox firstName = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox Lastname = new System.Windows.Forms.TextBox { Text = "something" };

            ComboBox gender = new System.Windows.Forms.ComboBox { Text = "something" };

            TextBox phone = new System.Windows.Forms.TextBox { Text = "something" };

            userDataBaseSettingsFormObject.SetFieldOrProperty("firstNameSet", firstName);
            userDataBaseSettingsFormObject.SetFieldOrProperty("lastNameSet", Lastname);
            userDataBaseSettingsFormObject.SetFieldOrProperty("genderSet", gender);
            userDataBaseSettingsFormObject.SetFieldOrProperty("phoneSet", phone);

            // Act
            Boolean result = (Boolean)userDataBaseSettingsFormObject.Invoke("hasEmptyFields");

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Unit tests for has empty fields, for state where the form has all empty fields.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodHasEmptyFieldsForAllEmptyFields()
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

            HomeForm homeref = new HomeForm(dummyStudent);
            userDataBaseSettings userDataBaseSettings = new userDataBaseSettings(dummyStudent, homeref);
            PrivateObject userDataBaseSettingsFormObject = new PrivateObject(userDataBaseSettings);

            // Act
            Boolean result = (Boolean)userDataBaseSettingsFormObject.Invoke("hasEmptyFields");

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
