﻿using BCITDesktop;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

/// <summary>
/// Student class unit tests.
/// Authors: Eric Dong
/// Include here date/revisions: Version 1.0, April 10th 2021.
/// </summary>
namespace UnitTestProject
{
    [TestClass]
    public class UnitTestStudent
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
        /// Unit test for getting an existing student from firebase using class method getStudent;
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodGetStudentForExistingStudent()
        {
            //Arrange
            client = new FireSharp.FirebaseClient(firebaseConfigurations);
            if (client == null)
            {
                Console.WriteLine("Test failed, cannot connect to firebase");
                return;
            }
            String testStudentID = "A00000001";
            Student actualStudent;

            // expected student values for test student in database
            Student expectedStudent = new Student()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                StudentNumber = testStudentID,
                Email = "teststudent@test.test",
                Password = "TestPassword",
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };

            //Act
            actualStudent = Student.getStudent(client, testStudentID);

            //Assert
            Assert.AreEqual(expectedStudent.FirstName, actualStudent.FirstName);
            Assert.AreEqual(expectedStudent.LastName, actualStudent.LastName);
            Assert.AreEqual(expectedStudent.StudentNumber, actualStudent.StudentNumber);
            Assert.AreEqual(expectedStudent.Email, actualStudent.Email);
            Assert.AreEqual(expectedStudent.Password, actualStudent.Password);
            Assert.AreEqual(expectedStudent.Gender, actualStudent.Gender);
            Assert.AreEqual(expectedStudent.Phone, actualStudent.Phone);
            Assert.AreEqual(expectedStudent.DateOfBirth, actualStudent.DateOfBirth);
        }

        /// <summary>
        /// Unit test for calling getStudent with a non existant student id;
        /// Author: Eric Dong
        /// </summary>
        [TestMethod]
        public void TestMethodGetStudentForNonExistingStudent()
        {
            //Arrange
            client = new FireSharp.FirebaseClient(firebaseConfigurations);
            if (client == null)
            {
                Console.WriteLine("Test failed, cannot connect to firebase");
                return;
            }
            String testStudentID = "A0asdasdasdasdasd";
            Student actualStudent;

            //Act
            actualStudent = Student.getStudent(client, testStudentID);

            //Assert
            Assert.AreEqual(null, actualStudent);
        }

        /// <summary>
        /// Unit test for testing equality method for two Student objects with the same student number and passwords.
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
            String testStudentID = "A00000001";
            String testStudentPassword = "Password123";

            // expected student values for test student in database
            Student studentOne = new Student()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                StudentNumber = testStudentID,
                Email = "teststudent@test.test",
                Password = testStudentPassword,
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };

            Student studentTwo = new Student()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                StudentNumber = testStudentID,
                Email = "teststudent@test.test",
                Password = testStudentPassword,
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };

            //Act
            Boolean testResult = Student.areTheSameUsers(studentTwo, studentTwo);

            //Assert
            Assert.AreEqual(true, testResult);
        }

        /// <summary>
        /// Unit test for testing equality method for two Student objects with different student number and passwords.
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
            String testStudentOneID = "A00000001";
            String testStudentTwoID = "A00000002";
            String testStudentOnePassword = "Password123";
            String testStudentTwoPassword = "Password456";

            // expected student values for test student in database
            Student studentOne = new Student()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                StudentNumber = testStudentOneID,
                Email = "teststudent@test.test",
                Password = testStudentOnePassword,
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };

            Student studentTwo = new Student()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                StudentNumber = testStudentTwoID,
                Email = "teststudent@test.test",
                Password = testStudentTwoPassword,
                Gender = "Male",
                Phone = "0000000000",
                DateOfBirth = DateTime.Parse("2021-04-12T00:00:00-07:00")
            };

            //Act
            Boolean testResult = Student.areTheSameUsers(studentOne, studentTwo);

            //Assert
            Assert.AreEqual(false, testResult);
        }
    }
}
