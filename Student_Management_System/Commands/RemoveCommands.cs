using CliFx;
using CliFx.Attributes;
using System.Threading.Tasks;
using static Student_Management_System.Manager.File_Manager;

namespace Student_Management_System.Commands
{
    public class RemoveCommands
    {
        [Command("remove")]
        public class RemoveCommand : ICommand
        {
            [CommandParameter(0, Description = "ID of the Student.")]
            public int  ID { get; set; }

            public ValueTask ExecuteAsync(IConsole console)
            {
                using (var fileManager = new FileManager("temp.json"))
                {
                    fileManager.Remove(ID);
                    return default;
                }
            }
        }
    }
}
