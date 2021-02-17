using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class StudentManagemenet
    {
        private List<Object> studentCollection;
        public StudentManagemenet()
        {
            this.studentCollection = new List<Object>();
        }


        public void addStudent(Object student)
        {
            studentCollection.Add(student);
        }

    }
}

