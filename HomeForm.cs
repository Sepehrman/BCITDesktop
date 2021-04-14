using System;
using System.ComponentModel;
using System.Drawing;
using BCITDesktop.Properties;
using System.Windows.Forms;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;

/// <summary>
/// Term Project, Main form of program. 
/// Authors: Sepehr Mansouri, Eric Dong, Jacob Tan
/// Include here date/revisions: Version 3.0, April 12th 2021.
/// </summary>
namespace BCITDesktop
{
    /// <summary>
    /// Main form of program after user logs in.
    /// Authors: Eric Dong, Jacob Tan
    /// </summary>
    public partial class HomeForm : Form
    {
        IFirebaseClient client;
        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };


        private Form activeForm = null;

        /// <summary>
        /// Delegate for updating information after information about the user is changed.
        /// Authors: Eric Dong
        /// </summary>
        private delegate void updateLabelsDelegate();
        private updateLabelsDelegate updateStudentLabels;
        private updateLabelsDelegate updateInstructorLabels;

        private Student student;
        private Instructor instructor;

        /// <summary>
        /// Initializes the form, the sutdent and delegate.
        /// Authors: Eric Dong, Jacob Tan
        /// </summary>
        /// <param name="studentObj"></param>
        public HomeForm(Student studentObj)
        {
            InitializeComponent();
            this.student = studentObj;
            this.updateStudentLabels = new updateLabelsDelegate(updateStudentLabelsmethod);
        }
        /// <summary>
        /// Overloaded constructor for instructors
        /// </summary>
        /// <param name="instructorObj"></param>
        public HomeForm(Instructor instructorObj)
        {
            InitializeComponent();
            this.instructor = instructorObj;
            this.updateInstructorLabels = new updateLabelsDelegate(updateInstructorLabelsmethod);
        }

        /// <summary>
        /// Updates the student if it is changed in the database asyncronisly.
        /// Authors: Eric Dong
        /// </summary>
        private async void  updateStudent()
        {
            // Get response on update asyncronisly.
            EventStreamResponse response = await this.client.OnAsync("Students",
            // if the update is an add event
            added: (s, args, context) =>
            {
            },
            // if the update is a change event, update the student attribute and labels.
            changed: (s, args, context) =>
            {
                FirebaseResponse responseStudent = client.Get(@"Students/" + this.student.StudentNumber);
                Student updatedStudent = responseStudent.ResultAs<Student>();

                // update the student in this.
                this.student = updatedStudent;

                // call the method to update the labels
                this.Invoke(this.updateStudentLabels);
            },
            // if the update is a remove event.
            removed: (s, args, context) =>
            {
            });
        }

        /// <summary>
        /// On form load, initalize the client for database, set the labels with information from database.
        /// Authors: Eric Dong, Jacob Tan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Homeform_Load(object sender, EventArgs e)
        {
            if (this.instructor == null)
            {
                // Update the student labels
                updateStudentLabelsmethod();
            }
            else
            {
                updateInstructorLabelsmethod();
            }
            
            //  Set Windows Size
            changeSizeToAppSettingsSize();

            // Set the method for when a property in settings is changed.
            Properties.Settings.Default.PropertyChanged += SettingsChanged;

            client = new FireSharp.FirebaseClient(firebaseConfigurations);
            if (client != null)
            {
            }
            else
            {
                this.updateStudent();
            }
        }

        /// <summary>
        /// Helper function for opening child forms to use in this form.
        /// Authors: Jacob Tan
        /// </summary>
        /// <param name="childForm"></param>
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

            // sets the child form attributes
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

        /// <summary>
        /// Handler to open the dashboard form.
        /// Authors: Jacob Tan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HomeButton_Click(object sender, EventArgs e)
        {
            if (instructor == null)
            {
                openChildForm(new Dashboard(student, this));
            }
            else
            {
                openChildForm(new Dashboard(instructor, this));
            }
        }

        /// <summary>
        /// Handler to open the settings form.
        /// Authors: Eric Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void openSettingsForm(object sender, EventArgs e)
        {
            openChildForm(new SettingsForm(student, this));
        }

        /// <summary>
        /// Handler to close active child form
        /// Authors: Jacob Tan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logo_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
        }

        /// <summary>
        /// Handler to log the user out and close the form.
        /// Authors: Jacob Tan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Function to add to properties default property changed.
        /// Authors: Eric Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsChanged(object sender, PropertyChangedEventArgs e)
        {
            changeSizeToAppSettingsSize();
        }

        /// <summary>
        /// Changes the size of the form to the application setting.
        /// Authors: Eric Dong
        /// </summary>
        private void changeSizeToAppSettingsSize()
        {
            if (Settings.Default.ApplicationSize != null)
            {
                this.Size = Settings.Default.ApplicationSize;
            }
        }

        /// <summary>
        /// Method for delegate to update the labels containing user information.
        /// Authors: Eric Dong
        /// </summary>
        public void updateStudentLabelsmethod()
        {
            userName.Text = student.FirstName + ' ' + student.LastName;
            userNumber.Text = student.StudentNumber;
            header.Text = "Welcome " + student.FirstName;
        }
        /// <summary>
        /// Method for delegate to update the labels containing user information.
        /// Authors: Eric Dong
        /// </summary>
        public void updateInstructorLabelsmethod()
        {
            userName.Text = instructor.FirstName + ' ' + instructor.LastName;
            userNumber.Text = instructor.InstructorNumber;
            header.Text = "Welcome " + instructor.FirstName;
        }
    }
}
