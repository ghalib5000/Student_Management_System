using CliFx;
using CliFx.Attributes;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static Student_Management_System.Manager.File_Manager;

namespace Student_Management_System.Commands
{
    public class UpdateCommands
    {
        [Command("update")]
        public class UpdateCommand : ICommand
        {
            [CommandParameter(0, Description = "Name of the Student")]
            public string name { get; set; }
            [CommandOption("age", 'a', Description = "Age of the Student")]
            public int age { get; set; }
            [CommandOption("sub", 's', Description = "Subject of the Student")]
            public string subject { get; set; }
            [CommandOption("gpa", 'g', Description = "GPA of the Student")]
            public double gpa { get; set; }
            public ValueTask ExecuteAsync(IConsole console)
            {
                Student.Student std = new Student.Student();
               
                using (var fileManager = new FileManager("temp.json"))
                {
                    var temp = fileManager.GetValues();
                    foreach(var value in temp.Values)
                    {
                        if(name == value.name)
                        {
                            std = value;
                            if (age != default)
                                std.age = age;
                            if (subject != default)
                                std.subject = subject;
                            if (gpa != default)
                                std.gpa = gpa;

                            fileManager.Remove(name);
                            fileManager.AddValue(name, std);
                           string  tmp = "Added Student with name " + name;
                            console.Output.WriteLine(tmp);
                            FileManager.log.Information(tmp);
                            break;
                        }
                    }


                    return default;
                }
            }
        }
    }
}
