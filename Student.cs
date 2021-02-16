using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public class Student
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        private String _firstName { get; set; }
        private String _lastName { get; set; }
        private String _studentNumber { get; set; }
        private DateTime _dateOfBirth { get; set; }
        private String _programName { get; set; }

        public Student(String firstName, String lastName, String studentNumber, DateTime dateOfBirth, String programName)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._studentNumber = studentNumber;
            this._dateOfBirth = dateOfBirth;
            this._programName = programName;
        }



        public String FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public String LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public String StudentNumber
        {
            get { return _studentNumber; }
            set { _studentNumber = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public String ProgramName
        {
            get { return _programName; }
            set { _programName = value; }
        }




        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
