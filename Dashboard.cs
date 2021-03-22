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

        public Dashboard(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void addCourseBtn_Click(object sender, EventArgs e)
        {
            Form courseReg = new CourseReg(student);
            courseReg.ShowDialog();
        }
    }
}
