using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace BCITDesktop
{
    public partial class CourseReg : Form
    {
        Student student;
        public CourseReg(Student studentObj)
        {
            InitializeComponent();
            this.student = studentObj;
        }

        IFirebaseClient client;
        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };

        private bool hasEmptyFields()
        {
            if (string.IsNullOrWhiteSpace(crsName.Text) || (string.IsNullOrWhiteSpace(crsID.Text))
                || string.IsNullOrWhiteSpace(instrName.Text) || string.IsNullOrWhiteSpace(credits.Text))
            {
                return true;
            }
            return false;
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            if (hasEmptyFields())
            {
                MessageBox.Show("Please fill in all the fields to proceed");
            }
            else
            {
                int creds = Int32.Parse(credits.Text);
                Course c = new Course(crsName.Text, crsID.Text, creds, instrName.Text) 
/*                {
                courseName = crsName.Text,
                courseID = crsID.Text,
                courseCreds = creds,
                instructor = instrName.Text            

                };*/

                //FirebaseResponse r = client.Get(@"Students/" + student.FirstName);
                //Student s = r.ResultAs<Student>();
                //s.c1 = c;

                SetResponse response = client.Set(@"Students/"+ student.FirstName + "/Courses/" + crsName.Text , c);
                MessageBox.Show("Registered " + c);
                this.Close();
                this.Dispose();
            }
        }

        private void CourseReg_Load(object sender, EventArgs e)
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
    }
}
