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

        public Dashboard(Student student, HomeForm homeRef)
        {
            InitializeComponent();
            this.student = student;
            this.parent = homeRef;
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(firebaseConfigurations);
                FirebaseResponse response = await client.GetAsync("Students/" + student.FirstName + "/Courses");
                Dictionary<string, Course> data = response.ResultAs<Dictionary<string, Course>>();
                
                if (data != null)
                {
                    foreach (Course c in data.Values)
                    {
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
                    Label l = new Label();
                    l.Size = new Size(500, 200);
                    l.Text = "You are currently not enrolled in any courses";
                    l.TextAlign = ContentAlignment.TopLeft;
                    l.Font = new Font("Nirmala UI", 18f);
                    flowLayoutPanel.Controls.Add(l);
                }
            }

            catch
            {
                MessageBox.Show("Connection Error");
            }
        }

        private void openCourseForm(object sender, EventArgs e)
        {
            Button b = (Button) sender;
            Form courseForm = new CourseForm(student, parent, b.Name);
            parent.openChildForm(courseForm);
        }

        private void addCourseBtn_Click(object sender, EventArgs e)
        {
            Form courseReg = new CourseReg(student);
            courseReg.ShowDialog();
            flowLayoutPanel.Controls.Clear();
            this.Dashboard_Load(null, EventArgs.Empty);
        }
    }
}
