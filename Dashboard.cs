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
        IFirebaseClient client;
        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };

        public Dashboard(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(firebaseConfigurations);
                FirebaseResponse response = await client.GetAsync("Students/" + student.FirstName + "/Courses");
                Dictionary<string, Course> data = response.ResultAs<Dictionary<string, Course>>();
                
                foreach (Course c in data.Values)
                {
                    Button b = new Button();
                    b.Size = new Size(170, 170);
                    b.Text = c.courseID + "\n" + c.courseName;
                    b.TextAlign = ContentAlignment.TopLeft;
                    b.Font = new Font("Nirmala UI", 15.75f);
                    b.ForeColor = Color.FromArgb(0, 0, 0);
                    b.Padding = new Padding(7, 5, 0, 0);
                    flowLayoutPanel.Controls.Add(b);
                }
            }

            catch
            {
                MessageBox.Show("Connection Error");
            }
        }

        private void addCourseBtn_Click(object sender, EventArgs e)
        {
            Form courseReg = new CourseReg(student);
            courseReg.ShowDialog();
            this.Dashboard_Load(null, EventArgs.Empty);
        }
    }
}
