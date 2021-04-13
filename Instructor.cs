using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Response;
using FireSharp.Interfaces;
/// <summary>
/// Instructor class
/// Author: Jacob Tan
/// Include here date/revisions: Version 1.0, April 12th 2021.
/// </summary>
namespace BCITDesktop
{
    public class Instructor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string InstructorNumber { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        private static string errorMsg = "An error occured";

        /// <summary>
        /// Show error message to user.
        /// </summary>
        public static void ShowErrorMessage()
        {
            System.Windows.Forms.MessageBox.Show(errorMsg);
        }
        /// <summary>
        /// Instructor login auth
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static bool areTheSameUsers(Instructor i1, Instructor i2)
        {
            if (i1 == null || i2 == null)
            {
                return false;
            }
            if (i1.InstructorNumber != i2.InstructorNumber)
            {
                errorMsg = "Instructor does not exist";
                return false;
            }
            if (i1.Password != i2.Password)
            {
                errorMsg = "Password does not match!";
                return false;
            }
            return true;

        }
        /// <summary>
        /// Return student object using passed IFireBaseClient and the student id.
        /// Authors: Eric Dong
        /// </summary>
        /// <param name="client"> a IFireBaseClient, the client for the firebase database that stores your students data</param>
        /// <param name="studentID">a String, the student id</param>
        /// <returns></returns>
        public static Instructor getInstructor(IFirebaseClient client, String instrID)
        {
            FirebaseResponse response = client.Get(@"Instructors/" + instrID);
            return response.ResultAs<Instructor>();
        }
    }

}
