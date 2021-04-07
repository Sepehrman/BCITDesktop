using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCITDesktop
{
    public class Course
    {

        public string courseName { get; set; }
        public string courseID { get; set; }
        public int courseCreds { get; set; }
        public string instructor { get; set; }
        //private List<Student> _classList { get; set; }


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
