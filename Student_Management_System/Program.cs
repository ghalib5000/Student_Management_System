using BasicLogger;
using CliFx;
using System;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public static class Program
    {
        public static async Task<int> Main() =>
            await new CliApplicationBuilder()
                .AddCommandsFromThisAssembly()
                .Build()
                .RunAsync();
    }
}
