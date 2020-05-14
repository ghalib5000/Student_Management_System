using CliFx;
using CliFx.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Student_Management_System.Manager.File_Manager;

namespace Student_Management_System.Commands
{
    public class Commands
    {
        static Student.Student std;
        static int i = 1;

        [Command("add")]
        public class AddCommand : ICommand
        {
            [CommandParameter(0, Description = "Name of the Student")]
            public string name { get; set; }
            [CommandParameter(1, Description = "Age of the Student")]
            public int age { get; set; }
            [CommandParameter(2, Description = "Subject of the Student")]
            public string subject { get; set; }
            [CommandParameter(3, Description = "GPA of the Student")]
            public double gpa { get; set; }
            public ValueTask ExecuteAsync(IConsole console)
            {
                std = new Student.Student();
                std.id = i;
                std.name = name;
                std.age = age;
                std.subject = subject;
                std.gpa = gpa;
                using (var fileManager = new FileManager("temp"))
                {
                    fileManager.AddValue(name, std);
                    

                    //inserting  a new Student into the ready queue
                    Console.WriteLine("Added Student with name " + name);
                    return default;
                }
            }
        }

        [Command("show")]
        public class ShowCommand : ICommand
        {
            public ValueTask ExecuteAsync(IConsole console)
            {
                using (var fileManager = new FileManager("temp"))
                {
                    foreach (var data in fileManager.GetValues())
                    {
                        Console.WriteLine("Student Name is: " + data.Key +
                            "\nThe Student info is:");
                        Console.WriteLine("ID: " + data.Value.id);
                        Console.WriteLine("Name: " + data.Value.name);
                        Console.WriteLine("Age: " + data.Value.age);
                        Console.WriteLine("Subject: " + data.Value.subject);
                        Console.WriteLine("GPA: " + data.Value.gpa + "\n");
                    }
                    return default;
                }
            }
        }

        [Command("remove")]
        public class RemoveCommand : ICommand
        {
            [CommandParameter(0, Description = "Name of the Student.")]
            public string Name { get; set; }

            public ValueTask ExecuteAsync(IConsole console)
            {


                using (var fileManager = new FileManager("temp"))
                {
                    fileManager.Remove(Name);

                    Console.WriteLine("Student " + Name + " is removed from database");

                    return default;
                }
            }

        }


    }
}
