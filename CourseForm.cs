using System;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

/// <summary>
/// Term Project, Form for displaying a course.
/// Authors: Jacob Tan
/// Include here date/revisions: Version 1.0, April 7th 2021.
/// </summary>
namespace BCITDesktop
{
    /// <summary>
    /// Form that displays a course.
    /// Authors: Jacob Tan
    /// </summary>
    public partial class CourseForm : Form
    {
        private Student student;
        private Instructor instructor;
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

        /// <summary>
        /// Initalizes the form.
        /// Authors: Jacob Tan
        /// </summary>
        /// <param name="student">The user</param>
        /// <param name="homeRef"></param>
        /// <param name="courseName">The course name</param>
        public CourseForm(Student student, HomeForm homeRef, string courseName)
        {
            InitializeComponent();
            this.student = student;
            this.parent = homeRef;
            this.courseName = courseName;
        }
        public CourseForm(Instructor instructor, HomeForm homeRef, string courseName)
        {
            InitializeComponent();
            this.instructor = instructor;
            this.parent = homeRef;
            this.courseName = courseName;
        }

        /// <summary>
        /// On load, gets the course information, and sets the labels.
        /// Authors: Jacob Tan, Eric Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CourseForm_Load(object sender, EventArgs e)
        {
            try
            {
                // gets the client, notifies user with message box if that fails.
                client = new FireSharp.FirebaseClient(firebaseConfigurations);
                if (client == null)
                {
                    MessageBox.Show("Connection Error");
                }

                FirebaseResponse response;
                // get courses from student
                if (this.instructor == null)
                {
                    response = await client.GetAsync("Students/" + student.StudentNumber + "/Courses/"
                                            + courseName);
                }
                else
                {
                    response = await client.GetAsync("Instructors/" + instructor.InstructorNumber + "/Courses/"
                        + courseName);
                }

                // convert response to course class.
                Course course = response.ResultAs<Course>();

                // set the labels
                courseIDLabel.Text = course.courseID;
                courseNameLabel.Text = course.courseName;
            }
            catch
            {
                MessageBox.Show("Connection Error");
            }
        }

        /// <summary>
        /// Handles the form closing.
        /// Authors: Jacob Tan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeFormBtn_Click(object sender, EventArgs e)
        {
            parent.HomeButton_Click(sender, e);
        }
    }
}
