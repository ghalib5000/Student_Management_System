using CliFx;
using CliFx.Attributes;
using System.Threading.Tasks;
using static Student_Management_System.Manager.File_Manager;

namespace Student_Management_System.Commands
{
    public class ADDCommands
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
                    console.Output.WriteLine("Added Student with name " + name);
                    return default;
                }
            }
        }

    }
}
