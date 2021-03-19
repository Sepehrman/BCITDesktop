using System;

namespace BCITDesktop
{
	public class Student
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public string StudentNumber { get; set; }
		public string Gender { get; set; }
		public string Phone { get; set; }
		public DateTime DateOfBirth { get; set; }

		public static string errorMessage;

		public static void ShowErrorMessage()
        {
			System.Windows.Forms.MessageBox.Show(errorMessage);
        }
       


/*		public Student(string firstName, string lastName, string email, string password, string gender, string phone, DateTime dateOfBirth)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
			this.Password = password;
			this.Gender = gender;
			this.Phone = phone;
			this.DateOfBirth = dateOfBirth;

		}*/


	}

}
