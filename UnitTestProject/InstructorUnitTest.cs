using BCITDesktop;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

/// <summary>
/// Instructor class unit tests.
/// Authors: Eric Dong
/// Include here date/revisions: Version 1.0, April 10th 2021.
/// </summary>
namespace UnitTestProject
{
    [TestClass]
    public class UnitTestInstructor
    {

        /**
        * Firebase initialization
        */
        IFirebaseClient client;
        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };

        /// <summary>
        /// Unit test for getting an existing instructor from firebase using class method getStudent;
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodGetInstructorForExistingInstructor()
        {
            //ArrangeInstructor
            client = new FireSharp.FirebaseClient(firebaseConfigurations);
            if (client == null)
            {
                Console.WriteLine("Test failed, cannot connect to firebase");
                return;
            }
            String testInstructorID = "A00000001";
            Instructor actualInstructor;

            // expected Instructor values for test Instructor in database
            Instructor expectedInstructor = new Instructor()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                InstructorNumber = testInstructorID,
                Email = "testinstructor@test.test",
                Password = "TestPassword",
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };

            //Act
            actualInstructor = Instructor.getInstructor(client, testInstructorID);

            //Assert
            Assert.AreEqual(expectedInstructor.FirstName, actualInstructor.FirstName);
            Assert.AreEqual(expectedInstructor.LastName, actualInstructor.LastName);
            Assert.AreEqual(expectedInstructor.InstructorNumber, actualInstructor.InstructorNumber);
            Assert.AreEqual(expectedInstructor.Email, actualInstructor.Email);
            Assert.AreEqual(expectedInstructor.Password, actualInstructor.Password);
            Assert.AreEqual(expectedInstructor.Gender, actualInstructor.Gender);
            Assert.AreEqual(expectedInstructor.Phone, actualInstructor.Phone);
            Assert.AreEqual(expectedInstructor.DateOfBirth, actualInstructor.DateOfBirth);
        }

        /// <summary>
        /// Unit test for calling getStudent with a non existant student id;
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodGetInstructorForNonExistingInstructor()
        {
            //Arrange
            client = new FireSharp.FirebaseClient(firebaseConfigurations);
            if (client == null)
            {
                Console.WriteLine("Test failed, cannot connect to firebase");
                return;
            }
            String testInstructorID = "A0asdasdasdasdasd";
            Instructor actualInstructor;

            //Act
            actualInstructor = Instructor.getInstructor(client, testInstructorID);

            //Assert
            Assert.AreEqual(null, actualInstructor);
        }

        /// <summary>
        /// Unit test for testing equality method for two instructor objects with the same instructor number and passwords.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodAreTheSameUsersSameUsers()
        {
            //Arrange
            client = new FireSharp.FirebaseClient(firebaseConfigurations);
            if (client == null)
            {
                Console.WriteLine("Test failed, cannot connect to firebase");
                return;
            }
            String testInstructorID = "A00000001";
            String testInstructorPassword = "Password123";

            // expected Instructor values for test Instructor in database
            Instructor InstructorOne = new Instructor()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                InstructorNumber = testInstructorID,
                Email = "testInstructor@test.test",
                Password = testInstructorPassword,
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };

            Instructor InstructorTwo = new Instructor()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                InstructorNumber = testInstructorID,
                Email = "testInstructor@test.test",
                Password = testInstructorPassword,
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };

            //Act
            Boolean testResult = Instructor.areTheSameUsers(InstructorTwo, InstructorTwo);

            //Assert
            Assert.AreEqual(true, testResult);
        }

        /// <summary>
        /// Unit test for testing equality method for two instructor objects with different instructor number and passwords.
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodAreTheSameUsersDifferentUsers()
        {
            //Arrange
            client = new FireSharp.FirebaseClient(firebaseConfigurations);
            if (client == null)
            {
                Console.WriteLine("Test failed, cannot connect to firebase");
                return;
            }
            String testInstructorOneID = "A00000001";
            String testInstructorTwoID = "A00000002";
            String testInstructorOnePassword = "Password123";
            String testInstructorTwoPassword = "Password456";

            // expected Instructor values for test Instructor in database
            Instructor InstructorOne = new Instructor()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                InstructorNumber = testInstructorOneID,
                Email = "testInstructor@test.test",
                Password = testInstructorOnePassword,
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };

            Instructor InstructorTwo = new Instructor()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                InstructorNumber = testInstructorTwoID,
                Email = "testInstructor@test.test",
                Password = testInstructorTwoPassword,
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };

            //Act
            Boolean testResult = Instructor.areTheSameUsers(InstructorOne, InstructorTwo);

            //Assert
            Assert.AreEqual(false, testResult);
        }
    }
}
