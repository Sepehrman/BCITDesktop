using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCITDesktop.Properties;
using System.Windows.Forms;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;

namespace BCITDesktop
{
    public partial class HomeForm : Form
    {
        IFirebaseClient client;

        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };


        private Form activeForm = null;
        private delegate void updateLabelsDelegate();
        private updateLabelsDelegate updateStudentLabels;

        private Student student;
        public Student user
        {
            get { return student; }
            set
            {
                if (value != null)
                {
                    student = value;
                }
            }
        }

        public HomeForm(Student studentObj)
        {
            InitializeComponent();
            this.student = studentObj;
            this.updateStudentLabels = new updateLabelsDelegate(updateStudentLabelsmethod);
        }

        private async void  updateStudent()
        {
            EventStreamResponse response = await this.client.OnAsync("Students", added: (s, args, context) =>
            {
                // Console.WriteLine(args.Data);
            },
            changed: (s, args, context) =>
            {
                FirebaseResponse responseStudent = client.Get(@"Students/" + this.student.StudentNumber);
                Student updatedStudent = responseStudent.ResultAs<Student>(); // Database Results
                this.student = updatedStudent;
                this.Invoke(this.updateStudentLabels);
                Console.WriteLine(updatedStudent.FirstName);
            },
            removed: (s, args, context) =>
            {
            // Console.WriteLine(args);
            });
        }

        private void Homeform_Load(object sender, EventArgs e)
        {
            updateStudentLabelsmethod();
            // Set Windows Size

            changeSizeToAppSettingsSize();
            Properties.Settings.Default.PropertyChanged += SettingsChanged;

            try
            {
                client = new FireSharp.FirebaseClient(firebaseConfigurations);
            }

            catch
            {
                MessageBox.Show("Connection Error");
            }

            this.updateStudent();
        }

        public void openChildForm(Form childForm)
        {
            /**
             * Opens a new form in the right side panel
             */
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childPanel.Tag = childForm;
            childPanel.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();

            //Change button appearance for active form
            if (activeForm.GetType() == typeof(Dashboard) || activeForm.GetType() == typeof(CourseForm))
            {
                HomeButton.BackColor = Color.LightSlateGray;
            }
            
        }

        public void HomeButton_Click(object sender, EventArgs e)
        {
            openChildForm(new Dashboard(student, this));
        }

        public void openSettingsForm(object sender, EventArgs e)
        {
            openChildForm(new SettingsForm(student, this));
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SettingsChanged(object sender, PropertyChangedEventArgs e)
        {
            changeSizeToAppSettingsSize();
        }

        private void changeSizeToAppSettingsSize()
        {
            if (Settings.Default.ApplicationSize != null)
            {
                //this.Size = new Size(996, 619);
                //Settings.Default.ApplicationSize = new Size(996, 619);
                this.Size = Settings.Default.ApplicationSize;
                Console.WriteLine(Settings.Default.ApplicationSize);
                //Settings.Default.Save();
            }
        }

        public void updateStudentLabelsmethod()
        {
            userName.Text = student.FirstName + ' ' + student.LastName;
            userNumber.Text = student.StudentNumber;
            header.Text = "Welcome " + student.FirstName;
        }
    }
}
