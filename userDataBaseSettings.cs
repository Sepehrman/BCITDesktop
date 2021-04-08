using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace BCITDesktop
{
    public partial class userDataBaseSettings : Form
    {
        private HomeForm homeref;
        private Student student;
        private Student updatedStudent;
        IFirebaseClient client;

        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };

        private bool hasEmptyFields()
        {
            if (string.IsNullOrWhiteSpace(firstNameSet.Text) ||
                string.IsNullOrWhiteSpace(lastNameSet.Text) ||
                string.IsNullOrWhiteSpace(emailSet.Text) ||
                string.IsNullOrWhiteSpace(genderSet.Text) ||
                string.IsNullOrWhiteSpace(phoneSet.Text) ||
                // RECHECK THIS
                string.IsNullOrWhiteSpace(dobSet.Text))
            {
                return true;
            }
            return false;
        }

        public userDataBaseSettings(Student student, HomeForm homeref)
        {
            InitializeComponent();
            this.student = student;
            this.homeref = homeref;
        }

        private void userDataBaseSettings_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(firebaseConfigurations);
            }

            catch
            {
                MessageBox.Show("Connection Error");
            }
            this.student = Student.getStudent(client, this.student.StudentNumber);
            firstNameSet.Text = student.FirstName;
            lastNameSet.Text = student.LastName;
            emailSet.Text = student.Email;
            dobSet.Value = student.DateOfBirth;
            genderSet.Text = student.Gender;
            phoneSet.Text = student.Phone;
        }

        private void saveSettings_Handler(object sender, EventArgs e)
        {
            if (hasEmptyFields())
            {
                MessageBox.Show("Please fill in, all the fields to proceed");
            }
            else
            {
                updatedStudent = new Student()
                {
                    FirstName = firstNameSet.Text.ToUpper(),
                    LastName = lastNameSet.Text.ToUpper(),
                    StudentNumber = student.StudentNumber,
                    Email = emailSet.Text,
                    Password = student.Password,
                    Gender = genderSet.Text,
                    Phone = phoneSet.Text,
                    DateOfBirth = dobSet.Value.Date,
                };
                client.Update("Students/" + student.StudentNumber, updatedStudent);
                this.homeref.user = student;
                this.closeForm(sender, e);

            }      
        }

        private void closeForm(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
