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
    public partial class CourseForm : Form
    {
        private Student student;

        public CourseForm(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
