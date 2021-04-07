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
        private Student student;
        private HomeForm parent;
        private Student updatedStudent;
        /**
         * Firebase initialization
         */
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

        public userDataBaseSettings(Student student, HomeForm homeRef)
        {
            InitializeComponent();
            this.student = student;
            this.parent = homeRef;
        }

        private void userDataBaseSettings_Load(object sender, EventArgs e)
        {
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
                    DateOfBirth = dobSet.Value.Date),
                };
                client.UpdateAsync("@Student/" + student.StudentNumber, updatedStudent);
                closeForm(sender, e);
            }      
        }

        private void closeForm(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
