using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

/// <summary>
/// Term Project, Dashboard of the main form.
/// Authors: Jacob Tan
/// Include here date/revisions: Version 1.0, April 7th 2021.
/// </summary>
namespace BCITDesktop
{
    /// <summary>
    /// Child form that represents the dashboard for the main form of the app.
    /// Authors: Jacob Tan
    /// </summary>
    public partial class Dashboard : Form
    {
        private Student student;
        private HomeForm parent;
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
        /// <param name="student"></param>
        /// <param name="homeRef"></param>
        public Dashboard(Student student, HomeForm homeRef)
        {
            InitializeComponent();
            this.student = student;
            this.parent = homeRef;
        }

        /// <summary>
        /// On dashboard load, gets the courses from the student in the database, and displays them as buttons.
        /// Authors: Jacob Tan, Eric Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Dashboard_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(firebaseConfigurations);
            if (client != null)
            {
                
                // get courses the student has in the database.
                FirebaseResponse response = await client.GetAsync("Students/" + student.StudentNumber + "/Courses");
                Dictionary<string, Course> data = response.ResultAs<Dictionary<string, Course>>();
                
                if (data != null)
                {
                    foreach (Course c in data.Values)
                    {
                        // make new buttons with information of each course.
                        Button b = new Button();
                        b.Name = c.courseName;
                        b.Size = new Size(175, 175);
                        b.Text = c.courseID + "\n" + c.courseName;
                        b.TextAlign = ContentAlignment.TopLeft;
                        b.Font = new Font("Nirmala UI", 15.75f);
                        b.FlatAppearance.BorderSize = 0;
                        b.Padding = new Padding(7, 5, 0, 0);
                        flowLayoutPanel.Controls.Add(b);
                        b.Click += new EventHandler(openCourseForm);
                    }
                }
                else
                {
                    // make label if they arent in any courses.
                    Label l = new Label();
                    l.Size = new Size(500, 200);
                    l.Text = "You are currently not enrolled in any courses";
                    l.TextAlign = ContentAlignment.TopLeft;
                    l.Font = new Font("Nirmala UI", 18f);
                    flowLayoutPanel.Controls.Add(l);
                }
            }

            else
            {
                MessageBox.Show("Connection Error");
            }
        }

        /// <summary>
        /// Handles opening opening the course the user selected.
        /// Authors: Jacob Tan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openCourseForm(object sender, EventArgs e)
        {
            Button b = (Button) sender;
            Form courseForm = new CourseForm(student, parent, b.Name);

            parent.openChildForm(courseForm);
        }

        /// <summary>
        /// Handles opening a form for user to register a course.
        /// Authors: Jacob Tan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCourseBtn_Click(object sender, EventArgs e)
        {
            Form courseReg = new CourseReg(student);
            courseReg.ShowDialog();
            flowLayoutPanel.Controls.Clear();
            this.Dashboard_Load(null, EventArgs.Empty);
        }
    }
}
