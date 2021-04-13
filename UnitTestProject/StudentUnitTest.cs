using BCITDesktop;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void TestMethodGetStudent()
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
    }
}
