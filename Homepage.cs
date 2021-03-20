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
    public partial class Homepage : Form
    {
        /*        public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string Password { get; set; }
                public string StudentNumber { get; set; }
                public string Gender { get; set; }
                public string Phone { get; set; }
                public DateTime DateOfBirth { get; set; }*/

        private Student student;

        public Homepage(Student studentObj)
        {
            InitializeComponent();
            this.student = studentObj;
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            label2.Text = student.FirstName;
        }
    }
}
