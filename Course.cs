/// <summary>
/// Term Project, Class representing a course.
/// Authors: Jacob Tan, Sepehr mansouri
/// Include here date/revisions: Version 1.0, April 7th 2021.
/// </summary>

namespace BCITDesktop
{
    /// <summary>
    /// Class that represents a course.
    /// Authors: Jacob Tan, Sepehr mansouri
    /// </summary>
    public class Course
    {

        public string courseName { get; set; }
        public string courseID { get; set; }
        public int courseCreds { get; set; }
        public string instructor { get; set; }
        //private List<Student> _classList { get; set; }

        /// <summary>
        /// Enrolls a student to a course, not yet implemented.
        /// Authors: Jacob Tan, Sepehr mansouri
        /// </summary>
        /// <param name="student"></param>
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
