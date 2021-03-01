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
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void genderReg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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
            else if (passwordReg.Text != passwordConfReg.Text) {
                MessageBox.Show("Passwords are unmatching!");
            }

                Student student = new Student(firstNameReg.Text, LastnameReg.Text, emailReg.Text, passwordReg.Text, genderReg.Text, phoneReg.Text , dobReg.Value);
                SetResponse set = client.Set(@"Users/" + firstNameReg.Text, student);
                MessageBox.Show("Student has been registered successfully!");


        }

        private void phone_Click(object sender, EventArgs e)
        {
        }
    }

}
