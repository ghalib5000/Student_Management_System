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
                using (var fileManager = new FileManager("temp.json"))
                {
                    foreach (var data in fileManager.GetValues())
                    {
                        string temp = "Student Name is: " + data.Key +
                            "\nThe Student info is:";

                        console.Output.WriteLine(temp);
                        FileManager.log.Information(temp);

                        temp="ID: " + data.Value.id;
                        console.Output.WriteLine(temp);
                        FileManager.log.Information(temp);

                        temp = "Name: " + data.Value.name;
                        console.Output.WriteLine(temp);
                        FileManager.log.Information(temp);

                        temp = "Age: " + data.Value.age;
                        console.Output.WriteLine(temp);
                        FileManager.log.Information(temp);

                        temp = "Subject: " + data.Value.subject;
                        console.Output.WriteLine(temp);
                        FileManager.log.Information(temp);

                        temp = "GPA: " + data.Value.gpa + "\n";
                        console.Output.WriteLine(temp);
                        FileManager.log.Information(temp);

                    }
                    return default;
                }
            }
        }

       
    }
}
