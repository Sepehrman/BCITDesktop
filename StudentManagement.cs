using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class StudentManagemenet
    {
        private List<Student> studentCollection;
        public StudentManagemenet()
        {
            this.studentCollection = new List<Student>();
        }

        public void addStudent(Student student)
        {
            studentCollection.Add(student);
        }

        public int studentCount()
        {
            return studentCollection.Count;
        }
    }
}

