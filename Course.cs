using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCITDesktop
{
    public class Course
    {

        private string courseName { get; set; }
        private string courseID { get; set; }
        private int courseCreds { get; set; }
        private string instructor { get; set; }
        //private List<Student> _classList { get; set; }

        public Course(String courseName, String courseID, int courseCreds, String instructor)
        {
            this.courseName = courseName;
            this.courseID = courseID;
            this.courseCreds = courseCreds;
            this.instructor = instructor;
        }

        public void enrollStudent(Student student)
        {
            //_classList.Add(student);
        }

        //public int classCount()
        //{
        //    return _classList.Count;
        //}
    }
}
