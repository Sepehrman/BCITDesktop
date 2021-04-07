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
using FireSharp.Response;
using FireSharp.Interfaces;

namespace BCITDesktop
{
    public partial class CourseForm : Form
    {
        private Student student;
        private HomeForm parent;
        private string courseName;
        /**
        * Firebase initialization
        */
        IFirebaseClient client;
        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };
        public CourseForm(Student student, HomeForm homeRef, string courseName)
        {
            InitializeComponent();
            this.student = student;
            this.parent = homeRef;
            this.courseName = courseName;
        }

        private async void CourseForm_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(firebaseConfigurations);
                FirebaseResponse response = await client.GetAsync("Students/" + student.FirstName + "/Courses/"
                                        + courseName);
                Course course = response.ResultAs<Course>();
                courseIDLabel.Text = course.courseID;
                courseNameLabel.Text = course.courseName;
            }
            catch
            {
                MessageBox.Show("Connection Error");
            }
        }

        private void closeFormBtn_Click(object sender, EventArgs e)
        {
            parent.HomeButton_Click(sender, e);
        }
    }
}
