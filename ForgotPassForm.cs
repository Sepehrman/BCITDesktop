using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using SocketLabs.InjectionApi;
using SocketLabs.InjectionApi.Message;
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
    public partial class ForgotPassForm : Form
    {
        public ForgotPassForm()
        {
            InitializeComponent();
        }


        private Student student;
        private Instructor instructor;
        IFirebaseClient client;


        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };

        private void sendEmailConfirmationStudent(Student studentObj)
        {
            int serverId = 38531;
            String injectionApiKey = "g3QBi56LwSs87Zpq4AXk";
            SocketLabsClient emailClient = new SocketLabsClient(serverId, injectionApiKey);
            BasicMessage message = new BasicMessage();
            message.Subject = "Registration Confirmation";
            message.HtmlBody = "<p><h3>Hello " + studentObj.FirstName + " This is your password reset details as you have requested.</h3>" +
                               "<br>Please make sure that you reset your password upon logging in</br>" +
                               "<br>Student Number: " + studentObj.StudentNumber + "</br>" +
                               "<br>Student Password: " + studentObj.Password + "</br>";
            message.From.Email = "NoReplyPasswordReset@bcit.ca";
            message.To.Add(studentObj.Email);
            var res = emailClient.Send(message);
            Console.WriteLine(res);
        }


        private void sendEmailConfirmationInstructor(Instructor instructorObj)
        {
            int serverId = 38531;
            String injectionApiKey = "g3QBi56LwSs87Zpq4AXk";
            SocketLabsClient emailClient = new SocketLabsClient(serverId, injectionApiKey);
            BasicMessage message = new BasicMessage();
            message.Subject = "Registration Confirmation";
            message.HtmlBody = "<p><h3>Hello " + instructorObj.FirstName + " This is your password reset details as you have requested.</h3>" +
                               "<br>Please make sure that you reset your password upon logging in</br>" +
                               "<br>Student Password: " + instructorObj.Password + "</br>" +
                               "<br>*** Please ignore this Email if you are not the recipient ***</br>";
            message.From.Email = "NoReplyPasswordReset@bcit.ca";
            message.To.Add(instructorObj.Email);
            var res = emailClient.Send(message);
            Console.WriteLine(res);
        }



        private bool matchesAgeStudent(Student stud)
        {
            if (stud.DateOfBirth == dateOfBirth.Value.Date)
            {
                return true;
            }
            return false;
        }


        private bool matchesAgeInstructor(Instructor stud)
        {
            if (stud.DateOfBirth == dateOfBirth.Value.Date)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Checks if there are any empty fields
        /// </summary>
        /// <returns></returns>
        private bool hasEmptyField()
        {
            if (string.IsNullOrWhiteSpace(IdNumTextBox.Text))
            {
                return true;
            }
            if (!studentRadio.Checked && !InstructorRadio.Checked) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Send Email once all requirements are met
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passEmail_OnClick(object sender, EventArgs e)
        {
            client = new FirebaseClient(firebaseConfigurations);

            if (!hasEmptyField())
            {
                if (studentRadio.Checked)
                {
                    Student resStudent = Student.getStudent(client, IdNumTextBox.Text); // Database Results
                    if (resStudent != null && matchesAgeStudent(resStudent))
                    {
                        MessageBox.Show("Please check your Email to view your password");
                        sendEmailConfirmationStudent(resStudent);
                        this.Close();
                        this.Dispose();
                    } else
                    {
                        MessageBox.Show("Details do not match please check your input details\n");
                    }
                } 
                else if (InstructorRadio.Checked)
                {
                    Instructor resInstructor = Instructor.getInstructor(client, IdNumTextBox.Text); // Database Results
                    if (resInstructor != null && matchesAgeInstructor(resInstructor))
                    {
                        MessageBox.Show("Please check your Email to view your password");
                        sendEmailConfirmationInstructor(resInstructor);
                        this.Close();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Details do not match please check your input details\n");

                    }
                }
            }
            else
            {
                MessageBox.Show("Please make sure all fields are filled");
            }
        }
    }
}
