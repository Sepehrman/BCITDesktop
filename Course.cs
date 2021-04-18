
using System.Collections.Generic;
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
        public List<Announcement> Announcements { get; set; }
        public string courseName { get; set; }
        public string courseID { get; set; }
        public int courseCreds { get; set; }
        public string instructor { get; set; }

    }
}
