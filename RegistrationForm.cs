using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BCITDesktop
{
    public partial class RegistrationForm : Form
    {
        Student student;
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void genderReg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Link to Database: https://console.firebase.google.com/u/0/project/bcitdesktop/database/bcitdesktop-default-rtdb/data
        IFirebaseClient client;
        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };


        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(firebaseConfigurations);
            }

            catch
            {
                MessageBox.Show("Connection Error");
            }
        }

        private bool hasEmptyFields()
        {
            if (string.IsNullOrWhiteSpace(firstNameReg.Text) ||
                string.IsNullOrWhiteSpace(LastnameReg.Text) ||
                string.IsNullOrWhiteSpace(emailReg.Text) ||
                string.IsNullOrWhiteSpace(studentNumReg.Text) ||
                string.IsNullOrWhiteSpace(passwordReg.Text) ||
                string.IsNullOrWhiteSpace(passwordConfReg.Text) ||
                string.IsNullOrWhiteSpace(genderReg.Text) ||
                string.IsNullOrWhiteSpace(phoneReg.Text) ||
                // RECHECK THIS
                string.IsNullOrWhiteSpace(dobReg.Text))
            {
                return true;
            }
            return false;
        }


        private void RegistrationBtn_Click(object sender, EventArgs e)
        {
            if (hasEmptyFields())
            {
                MessageBox.Show("Please fill in, all the fields to proceed");
            }
            else if (passwordReg.Text != passwordConfReg.Text)
            {
                MessageBox.Show("Passwords are unmatching!");
            }
            else
            {
                // Register users onto the realtime Database
                student = new Student() {
                    FirstName = firstNameReg.Text,
                    LastName = LastnameReg.Text,
                    StudentNumber = studentNumReg.Text,
                    Email = emailReg.Text,
                    Password = passwordReg.Text,
                    Gender = genderReg.Text,
                    Phone = phoneReg.Text,
                    DateOfBirth = dobReg.Value.Date
                };

                // Sets the database name under 'Users' and their first name
                SetResponse set = client.Set(@"Students/" + firstNameReg.Text, student);
                MessageBox.Show("Student has been registered successfully!");
                this.Close();
                this.Dispose();
            }
        }

        private void phone_Click(object sender, EventArgs e)
        {
        }
    }

}
