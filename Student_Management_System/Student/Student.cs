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
        public Student next;

        public Student()
        {
            id = 0;
            this.name = null;
            this.age = 0;
            this.subject = null;
            this.gpa = 0;
            next = null;
        }

        public static void Return_Students(Student std)
        {
            while(std.next!=null)
            {
                Console.WriteLine("Student ID is: " + std.id);
                Console.WriteLine("Student Name is: " + std.name);
                Console.WriteLine("Student Age is: " + std.subject);
                Console.WriteLine("Student Subject is: " + std.age);
                Console.WriteLine("Student GPA is: " + std.gpa);
                std = std.next;
            }
        }
    }
}
