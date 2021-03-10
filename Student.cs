using System;
using System.Collections.Generic;

namespace BCITDesktop
{
	public class Student
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Gender { get; set; }
		public string Phone { get; set; }
		public DateTime DateOfBirth { get; set; }
		public List<Course> EnrolledCourses { get; set; }


		public Student(string firstName, string lastName, string email, string password, string gender, string phone, DateTime dateOfBirth)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
			this.Password = password;
			this.Gender = gender;
			this.Phone = phone;
			this.DateOfBirth = dateOfBirth;
			this.EnrolledCourses = new List<Course>();
		}


	}

}
