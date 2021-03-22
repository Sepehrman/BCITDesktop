using System;
using System.Collections.Generic;

namespace BCITDesktop
{
	public class Student
	{
        private static string err = "An Error Occured";

        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public string StudentNumber { get; set; }
		public string Gender { get; set; }
		public string Phone { get; set; }
		public DateTime DateOfBirth { get; set; }
        public Course c1 { get; set; }
        public Course c2 { get; set; }
        //public List<Course> enrolledCourses { get; set; }

		public static void ShowErrorMessage()
        {
			System.Windows.Forms.MessageBox.Show(err);
        }


		public static bool areTheSameUsers(Student student1, Student student2)
        {
            if (student1 == null || student2 == null)
            {
                return false;
            }
            if (student1.FirstName != student2.FirstName)
            {
                err = "Student does not exist";
                return false;
            }
            if (student1.Password != student2.Password)
            {
                err = "Password does not match!";
                return false;
            }
            return true;
            
        }


	}

}
