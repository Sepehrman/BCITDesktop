using System;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;

/// <summary>
/// Term Project, User profile settings 
/// Authors: Eric Dong
/// Include here date/revisions: Version 1.0, April 7th 2021.
/// </summary>
namespace BCITDesktop
{
    /// <summary>
    /// Child form for editing user settings.
    /// Authors: Eric Dong
    /// </summary>
    public partial class userDataBaseSettings : Form
    {
        private HomeForm homeref;
        private Student student;
        private Student updatedStudent;

        /// <summary>
        /// initialize the client
        /// Authors: Eric Dong
        /// </summary>
        IFirebaseClient client;
        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };

        /// <summary>
        /// Checks if fields are empty, notify users if they are.
        /// Authors: Eric Dong, Sepher Mansouri
        /// Include here date/revisions: Version 1.0, April 7th 2021.
        /// </summary>
        /// <returns></returns>
        private bool hasEmptyFields()
        {
            if (string.IsNullOrWhiteSpace(firstNameSet.Text) ||
                string.IsNullOrWhiteSpace(lastNameSet.Text) ||
                string.IsNullOrWhiteSpace(emailSet.Text) ||
                string.IsNullOrWhiteSpace(genderSet.Text) ||
                string.IsNullOrWhiteSpace(phoneSet.Text) ||
                // RECHECK THIS
                dobSet.Value == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Initializer.
        /// Authors: Eric Dong
        /// </summary>
        /// <param name="student">Student object of the user</param>
        /// <param name="homeref">Parent</param>
        public userDataBaseSettings(Student student, HomeForm homeref)
        {
            InitializeComponent();
            this.student = student;
            this.homeref = homeref;
        }

        /// <summary>
        /// On load of form, connect firebase, and fill up fields with data of student from firebase. 
        /// Authors: Eric Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userDataBaseSettings_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(firebaseConfigurations);
            if (client == null)
            {
                MessageBox.Show("Connection Error");
                return;
            }
            // updates student in this.
            this.student = Student.getStudent(client, this.student.StudentNumber);

            // sets the labels
            firstNameSet.Text = student.FirstName;
            lastNameSet.Text = student.LastName;
            emailSet.Text = student.Email;
            dobSet.Value = student.DateOfBirth;
            genderSet.Text = student.Gender;
            phoneSet.Text = student.Phone;
        }

        /// <summary>
        /// Update the student info in the firebase database.
        /// Authors: Eric Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveSettings_Handler(object sender, EventArgs e)
        {
            if (hasEmptyFields())
            {
                MessageBox.Show("Please fill in, all the fields to proceed");
            }
            else
            {
                // create new student
                updatedStudent = new Student()
                {
                    FirstName = RegistrationForm.makeTitle(firstNameSet.Text),
                    LastName = RegistrationForm.makeTitle(lastNameSet.Text),
                    StudentNumber = student.StudentNumber,
                    Email = emailSet.Text,
                    Password = student.Password,
                    Gender = genderSet.Text,
                    Phone = phoneSet.Text,
                    DateOfBirth = dobSet.Value.Date,
                };
                client.Update("Students/" + student.StudentNumber, updatedStudent);
                this.closeForm(sender, e);
            }      
        }

        /// <summary>
        /// Closes the form, and disposes it.
        /// Authors: Eric Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeForm(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
