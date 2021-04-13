using System;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

/// <summary>
/// Term Project, Course registeration form.
/// Authors: Sepehr Mansouri, Jacob Tan
/// Include here date/revisions: Version 1.0, April 12th 2021.
/// </summary>
namespace BCITDesktop
{
    /// <summary>
    /// Child form for registering courses to the user in the database.
    /// Authors: Sepehr Mansouri, Jacob Tan
    /// </summary>
    public partial class CourseReg : Form
    {
        Student student;
        Instructor instructor;
        /// <summary>
        /// Initializer.
        /// Authors: Sepehr Mansouri, Jacob Tan
        /// </summary>
        /// <param name="studentObj"></param>
        public CourseReg(Student studentObj)
        {
            InitializeComponent();
            this.student = studentObj;
        }
        public CourseReg(Instructor instructor)
        {
            InitializeComponent();
            this.instructor = instructor;
            instrName.Text = instructor.FirstName + ' ' + instructor.LastName;
        }
        IFirebaseClient client;
        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };

        /// <summary>
        /// Checks if the fields are empty, notifies user via message box if they are.
        /// Authors: Jacob Tan
        /// </summary>
        /// <returns></returns>
        private bool hasEmptyFields()
        {
            // if any of the fields are blank.
            if (string.IsNullOrWhiteSpace(crsName.Text) || (string.IsNullOrWhiteSpace(crsID.Text))
                || string.IsNullOrWhiteSpace(instrName.Text) || string.IsNullOrWhiteSpace(credits.Text))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Handles registeration, if everything is valid it is added to the user in the database and notifies user, if it fails it will notify user, both are done with messagebox..
        /// Authors: Sepehr Mansouri, Jacob Tan, Eric Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regBtn_Click(object sender, EventArgs e)
        {
            if (hasEmptyFields())
            {
                MessageBox.Show("Please fill in all the fields to proceed");
            }
            else
            {
                int creds = Int32.Parse(credits.Text);
                
                // new course object from information
                Course c = new Course()
                {
                courseName = crsName.Text,
                courseID = crsID.Text,
                courseCreds = creds,
                instructor = instrName.Text            
                };

                // get the response
                if (instructor == null)
                {
                    SetResponse response = client.Set(@"Students/" + student.StudentNumber + "/Courses/" + crsName.Text, c);
                }
                else
                {
                    SetResponse response = client.Set(@"Instructors/"+ instructor.InstructorNumber + "/Courses/" + crsName.Text , c);
                }
                SetResponse response2 = client.Set(@"CourseList/" + crsName.Text, c);

                MessageBox.Show("Registered " + c);
                
                this.Close();
                this.Dispose();
            }
        }

        /// <summary>
        /// On page load, get client, if it fails notify user with messagebox.
        /// Authors: Sepehr Mansouri, Jacob Tan, Eric Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CourseReg_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(firebaseConfigurations);

            if (client == null)
            {
                MessageBox.Show("Connection Error");
            }
        }
    }
}
