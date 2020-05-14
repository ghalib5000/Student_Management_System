using CliFx;
using CliFx.Attributes;
using System.Threading.Tasks;
using static Student_Management_System.Manager.File_Manager;

namespace Student_Management_System.Commands
{
    public class ShowCommands
    {
       
        [Command("show")]
        public class ShowCommand : ICommand
        {
            public ValueTask ExecuteAsync(IConsole console)
            {
                using (var fileManager = new FileManager("temp"))
                {
                    foreach (var data in fileManager.GetValues())
                    {
                        
                        console.Output.WriteLine("Student Name is: " + data.Key +
                            "\nThe Student info is:");
                        console.Output.WriteLine("ID: " + data.Value.id);
                        console.Output.WriteLine("Name: " + data.Value.name);
                        console.Output.WriteLine("Age: " + data.Value.age);
                        console.Output.WriteLine("Subject: " + data.Value.subject);
                        console.Output.WriteLine("GPA: " + data.Value.gpa + "\n");
                    }
                    return default;
                }
            }
        }

       
    }
}
