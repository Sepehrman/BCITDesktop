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
                               "<br>Student Number: " + instructorObj.InstructorNumber + "</br>" +
                               "<br>Student Password: " + instructorObj.Password + "</br>";
            message.From.Email = "NoReplyPasswordReset@bcit.ca";
            message.To.Add(instructorObj.Email);
            var res = emailClient.Send(message);
            Console.WriteLine(res);
        }



/*        private string findEmailFromDatabase()
        {

        }*/



        private void ForgotPassForm_Load(object sender, EventArgs e)
        {



        }



        private bool hasEmptyFiled()
        {
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
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
            if (hasEmptyFiled())
            {
                MessageBox.Show("Please check to see if you have entered an email");
            }
            else
            {
                //sendEmailConfirmation();
                MessageBox.Show("Please check your Email for the password confirmation\n");
                this.Close();
                this.Dispose();
            }
        }
    }
}
