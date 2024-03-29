﻿using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using SocketLabs.InjectionApi;
using SocketLabs.InjectionApi.Message;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

/// <summary>
/// Term Project, User profile settings 
/// Authors: Sepehr Mansouri
/// Include here date/revisions: Version 2.0, April 7th 2021.
/// </summary>
namespace BCITDesktop
{

    /// <summary>
    /// Form for registering a user.
    /// Authors: Sepehr Mansouri
    /// Include here date/revisions: Version 2.0, April 7th 2021.
    /// </summary>
    public partial class RegistrationForm : Form
    {
        Student student;
        Instructor instructor;
        /// <summary>
        /// Initialized the form
        /// Authors: Sepehr Mansouri
        /// </summary>
        public RegistrationForm()
        {
            InitializeComponent();
        }

        // Link to Database: https://console.firebase.google.com/u/0/project/bcitdesktop/database/bcitdesktop-default-rtdb/data
        IFirebaseClient client;
        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };

        /// <summary>
        /// On form load, sets the client, notifies user with message box if it doesnt connect.
        /// Authors: Sepehr Mansouri, Eric Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(firebaseConfigurations);

            if (client == null)
            {
                MessageBox.Show("Connection Error");
            }
        }

        /// <summary>
        /// Check if fields are empty, returns if true or false.
        /// Authors: Sepehr Mansouri
        /// </summary>
        /// <returns></returns>
        private bool hasEmptyFields()
        {
            if (string.IsNullOrWhiteSpace(firstNameReg.Text) ||
                string.IsNullOrWhiteSpace(LastnameReg.Text) ||
                string.IsNullOrWhiteSpace(emailReg.Text) ||
                string.IsNullOrWhiteSpace(passwordReg.Text) ||
                string.IsNullOrWhiteSpace(passwordConfReg.Text) ||
                string.IsNullOrWhiteSpace(genderReg.Text) ||
                string.IsNullOrWhiteSpace(phoneReg.Text) ||
                // RECHECK THIS
                dobReg.Value == null ||
                !(studentRadio.Checked || InstructorRadio.Checked))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Generates a student number.
        /// Authors: Sepehr Mansouri
        /// </summary>
        /// <returns></returns>
        public static string generateStudentNumber()
        {
            Random rand = new Random();
            int randNum = rand.Next(111111, 99999999);
            string generator = randNum.ToString("00000000");
            return "A" + generator;
        }

        /// <summary>
        /// Sets the names to title case.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string makeTitle(string word)
        {
            CultureInfo culture_info = Thread.CurrentThread.CurrentCulture;
            TextInfo text_info = culture_info.TextInfo;

            return text_info.ToTitleCase(word);
        }

        /// <summary>
        /// Sends an Email through SocketLabs API
        /// </summary>
        /// <param name="studentObj"></param>
        private void sendEmailConfirmation(Student studentObj)
        {
            int serverId = 38531;
            String injectionApiKey = "g3QBi56LwSs87Zpq4AXk";
            SocketLabsClient emailClient = new SocketLabsClient(serverId, injectionApiKey);
            BasicMessage message = new BasicMessage();
            message.Subject = "Registration Confirmation";
            message.HtmlBody = "<p><h3>Welcome to BCIT " + studentObj.FirstName + " you can view your account's details bellow</h3>" +
                               "<br>Student Full Name: " + studentObj.FirstName + " " + studentObj.LastName + "</br>" +
                               "<br>Student Number: " + studentObj.StudentNumber + "</br>" +
                               "<br>Student Email: " + studentObj.Email + "</br>";
            message.From.Email = "NoReply@bcit.ca";
            message.To.Add(studentObj.Email);
            var res = emailClient.Send(message);
            Console.WriteLine(res);

        }



        /// <summary>
        /// Registers user if everything is valid, else notifies user with messagebox.
        /// Authors: Sepehr Mansouri, Eric Dong, Jacob Tan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationBtn_Click(object sender, EventArgs e)
        {
            if (hasEmptyFields())
            {
                MessageBox.Show("Please fill in, all the fields to proceed");
            }
            else if (passwordReg.Text != passwordConfReg.Text)
            {
                MessageBox.Show("Passwords are unmatching!");
            }
            // Student registration
            else if (studentRadio.Checked)
            {
                // Register users onto the realtime Database

                // create a new student
                student = new Student()
                {
                    FirstName = makeTitle(firstNameReg.Text),
                    LastName = makeTitle(LastnameReg.Text),
                    StudentNumber = generateStudentNumber(),
                    Email = emailReg.Text,
                    Password = passwordReg.Text,
                    Gender = genderReg.Text,
                    Phone = phoneReg.Text,
                    DateOfBirth = dobReg.Value.Date
                };


                // Checks if student number already exists in the database
                FirebaseResponse response = client.Get(@"Students/" + student.StudentNumber);
                Student resStudent = response.ResultAs<Student>(); // Database Results
                if (resStudent != null)
                {
                    string studentNumInDatabase = resStudent.StudentNumber;

                    while (studentNumInDatabase == student.StudentNumber)
                    {
                        student.StudentNumber = generateStudentNumber();
                    }
                }

                // Sets the database name under 'Students' and sets their first name as the main tab opener
                SetResponse set = client.Set(@"Students/" + student.StudentNumber, student);
                MessageBox.Show("Student has been registered successfully!\nPlease check your Email for confirmation of registration");
                sendEmailConfirmation(student);

                this.Close();
                this.Dispose();
            }
            //Instructor registration
            else if (InstructorRadio.Checked)
            {
                instructor = new Instructor()
                {
                    FirstName = makeTitle(firstNameReg.Text),
                    LastName = makeTitle(LastnameReg.Text),
                    InstructorNumber = generateStudentNumber(),
                    Email = emailReg.Text,
                    Password = passwordReg.Text,
                    Gender = genderReg.Text,
                    Phone = phoneReg.Text,
                    DateOfBirth = dobReg.Value.Date
                };
                // Checks if student number already exists in the database
                FirebaseResponse response = client.Get(@"Instructors/" + instructor.InstructorNumber);
                Instructor resInstructor = response.ResultAs<Instructor>(); // Database Results
                if (resInstructor != null)
                {
                    string instructorNuminDatabase = resInstructor.InstructorNumber;

                    while (instructorNuminDatabase == instructor.InstructorNumber)
                    {
                        instructor.InstructorNumber = generateStudentNumber();
                    }
                }

                // Sets the database name under 'Instructors' and sets their first name as the main tab opener
                SetResponse set = client.Set(@"Instructors/" + instructor.InstructorNumber, instructor);
                MessageBox.Show("Instructor has been registered successfully!\nYour dedicated instructor number is "
                    + instructor.InstructorNumber + "\nYou can use this to log into your account");
                // SocketLabs Library to send Emails to users who have just registered
                sendEmailConfirmation(student);

                this.Close();
                this.Dispose();
            }
        }

        /// <summary>
        /// Keypress event listener to only allow numbers 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
