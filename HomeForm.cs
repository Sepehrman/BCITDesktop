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
    public partial class HomeForm : Form
    {
        private Student student;
        private Form activeForm = null;

        public HomeForm(Student studentObj)
        {
            InitializeComponent();
            this.student = studentObj;
        }

        private void Homeform_Load(object sender, EventArgs e)
        {
            userName.Text = student.FirstName + ' ' + student.LastName;
            userNumber.Text = student.StudentNumber;
            header.Text = "Welcome " + student.FirstName;
        }

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childPanel.Tag = childForm;
            childPanel.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            openChildForm(new Dashboard(student));
        }
    }
}
