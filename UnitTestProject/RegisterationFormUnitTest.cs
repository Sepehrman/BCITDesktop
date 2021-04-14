using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BCITDesktop;
using System.Windows.Forms;

/// <summary>
/// Module containing unit tests for registeration form helper methods.
/// Authors: Eric Dong
/// Include here date/revisions: Version 1.0, April 10th 2021.
/// </summary>
namespace UnitTestProject
{
    /// <summary>
    /// Unit tests for helper methods of registeration form.
    /// Author: Eric Dong
    /// </summary>
    [TestClass]
    public class RegisterationFormUnitTest
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
        /// Test makeTitle for all lower case letters
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMakeTitleForAllLowerCase()
        {
            //Arrange
            String initialString = "alllowercase";
            String expectedString = "Alllowercase";

            // Act
            String actualString = RegistrationForm.makeTitle(initialString);

            // Assert
            Assert.AreEqual(expectedString, actualString);
        }

        /// <summary>
        /// Test makeTitle for all upper case letters
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMakeTitleForAllUpperCase()
        {
            //Arrange
            String initialString = "ALLUPPERCASE";
            String expectedString = "ALLUPPERCASE";

            // Act
            String actualString = RegistrationForm.makeTitle(initialString);

            // Assert
            Assert.AreEqual(expectedString, actualString);
        }

        /// <summary>
        /// Test makeTitle for mixed case letters
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMakeTitleForMixedCase()
        {
            //Arrange
            String initialString = "MixeDCaSE";
            String expectedString = "Mixedcase";

            // Act
            String actualString = RegistrationForm.makeTitle(initialString);

            // Assert
            Assert.AreEqual(expectedString, actualString);
        }

        /// <summary>
        /// Test hasEmptyFields method in registeration forms for empty fields.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodHasEmptyFieldsForEmptyFields()
        {
            //Arrange
            RegistrationForm registerationForm = new RegistrationForm();
            PrivateObject registerationFormObject = new PrivateObject(registerationForm);

            // Act
            Boolean result = (Boolean)registerationFormObject.Invoke("hasEmptyFields");

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Test hasEmptyFields method in registeration forms for non-empty fields.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodHasEmptyFieldsForNonEmptyFields()
        {
            //Arrange
            RegistrationForm registerationForm = new RegistrationForm();
            PrivateObject registerationFormObject = new PrivateObject(registerationForm);

            TextBox firstNameReg = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox LastnameReg = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox emailReg = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox passwordReg = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox passwordConfReg = new System.Windows.Forms.TextBox { Text = "something" };
            
            ComboBox genderReg = new System.Windows.Forms.ComboBox { Text = "something" };

            TextBox phoneReg = new System.Windows.Forms.TextBox { Text = "something" };

            RadioButton studentRadio = new System.Windows.Forms.RadioButton { Checked = true };

            DateTimePicker dobReg = new DateTimePicker();
            dobReg.Value = DateTime.Parse("2021-04-12T00:00:00-07:00");
            dobReg.Text = "2021-04-12T00:00:00-07:00";

            registerationFormObject.SetFieldOrProperty("firstNameReg", firstNameReg);
            registerationFormObject.SetFieldOrProperty("LastnameReg", LastnameReg);
            registerationFormObject.SetFieldOrProperty("emailReg", emailReg);
            registerationFormObject.SetFieldOrProperty("passwordReg", passwordReg);
            registerationFormObject.SetFieldOrProperty("passwordConfReg", passwordConfReg);
            registerationFormObject.SetFieldOrProperty("genderReg", genderReg);
            registerationFormObject.SetFieldOrProperty("phoneReg", phoneReg);
            registerationFormObject.SetFieldOrProperty("studentRadio", studentRadio);
            registerationFormObject.SetFieldOrProperty("dobReg", dobReg);

            // Act
            Boolean result = (Boolean)registerationFormObject.Invoke("hasEmptyFields");

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test hasEmptyFields method in login forms for non-empty fields.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodHasEmptyFieldsForSomeEmptyFields()
        {
            //Arrange
            RegistrationForm registerationForm = new RegistrationForm();
            PrivateObject registerationFormObject = new PrivateObject(registerationForm);

            TextBox firstNameReg = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox LastnameReg = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox emailReg = new System.Windows.Forms.TextBox { Text = "something" };

            TextBox passwordConfReg = new System.Windows.Forms.TextBox { Text = "something" };

            ComboBox genderReg = new System.Windows.Forms.ComboBox { Text = "something" };

            TextBox phoneReg = new System.Windows.Forms.TextBox { Text = "something" };

            RadioButton studentRadio = new System.Windows.Forms.RadioButton { Checked = true };

            registerationFormObject.SetFieldOrProperty("firstNameReg", firstNameReg);
            registerationFormObject.SetFieldOrProperty("LastnameReg", LastnameReg);
            registerationFormObject.SetFieldOrProperty("emailReg", emailReg);
            registerationFormObject.SetFieldOrProperty("passwordConfReg", passwordConfReg);
            registerationFormObject.SetFieldOrProperty("genderReg", genderReg);
            registerationFormObject.SetFieldOrProperty("phoneReg", phoneReg);
            registerationFormObject.SetFieldOrProperty("studentRadio", studentRadio);

            // Act
            Boolean result = (Boolean)registerationFormObject.Invoke("hasEmptyFields");

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Test phone event handler for digit inputs.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodphone_keypressDigitInput()
        {
            //Arrange
            RegistrationForm registerationForm = new RegistrationForm();
            PrivateObject registerationFormObject = new PrivateObject(registerationForm);
            TextBox sender = new System.Windows.Forms.TextBox { Text = "0" };

            KeyPressEventArgs e = new KeyPressEventArgs('0');

            // Act
            registerationFormObject.Invoke("phone_KeyPress", sender, e);

            // Assert
            Assert.AreEqual(false, e.Handled);
        }

        /// <summary>
        /// Test phone event handler for character inputs.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodphone_keypressCharacterInput()
        {
            //Arrange
            RegistrationForm registerationForm = new RegistrationForm();
            PrivateObject registerationFormObject = new PrivateObject(registerationForm);
            TextBox sender = new System.Windows.Forms.TextBox { Text = "0" };

            KeyPressEventArgs e = new KeyPressEventArgs('a');

            // Act
            registerationFormObject.Invoke("phone_KeyPress", sender, e);

            // Assert
            Assert.AreEqual(true, e.Handled);
        }

        /// <summary>
        /// Test phone event handler for . press when . already exists in textbox event.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodphone_keypressForMoreThanOneDecimal()
        {
            //Arrange
            RegistrationForm registerationForm = new RegistrationForm();
            PrivateObject registerationFormObject = new PrivateObject(registerationForm);
            KeyPressEventArgs e = new KeyPressEventArgs('.');

            TextBox sender = new System.Windows.Forms.TextBox { Text = "." };

            // Act
            registerationFormObject.Invoke("phone_KeyPress", sender, e);

            // Assert
            Assert.AreEqual(true, e.Handled);
        }


        /// <summary>
        /// Test phone event handler for . input with no previous . in textbox.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodphone_keypressNoPreviousDecimal()
        {
            //Arrange
            RegistrationForm registerationForm = new RegistrationForm();
            PrivateObject registerationFormObject = new PrivateObject(registerationForm);
            TextBox sender = new System.Windows.Forms.TextBox { Text = "0" };
            KeyPressEventArgs e = new KeyPressEventArgs('.');

            // Act
            registerationFormObject.Invoke("phone_KeyPress", sender, e);

            // Assert
            Assert.AreEqual(false, e.Handled);
        }


    }
}
