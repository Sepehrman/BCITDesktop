using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class Course
    {

        private String _courseName { get => _courseName; set => _courseName = value; }
        private String _courseID { get => _courseID; set => _courseID = value; }
        private int _courseNum { get => _courseNum; set => _courseNum = value; }
        private String _instructor { get => _instructor; set => _instructor = value; }
        private List<Student> _classList { get => _classList; set => _classList = value; }

        public Course(String courseName, String courseID, int courseNum, String instructor, List<Student> classList)
        {
            this._courseName = courseName;
            this._courseID = courseID;
            this._courseNum = courseNum;
            this._instructor = instructor;
            this._classList = classList;
        }

        public void enrollStudent(Student student)
        {
            _classList.Add(student);
        }

        public int classCount()
        {
            return _classList.Count;
        }
    }
}
