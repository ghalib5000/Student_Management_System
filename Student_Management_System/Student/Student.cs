using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Student_Management_System.Student
{
    class Student
    {
        public int id=0;
        public string name;
        public int age;
        public string subject;
        public double gpa;

        public Student()
        {
            id = 0;
            this.name = null;
            this.age = 0;
            this.subject = null;
            this.gpa = 0;
        }
      
    }
}
