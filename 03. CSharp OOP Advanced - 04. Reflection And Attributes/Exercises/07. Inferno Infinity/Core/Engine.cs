using _07._Inferno_Infinity.Contracts;
using System;
using System.Linq;

namespace _07._Inferno_Infinity.Core
{
    public class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;
        private IWriter writer;
        private IReader reader;

        public Engine(ICommandInterpreter commandInterpreter, IWriter writer, IReader reader)
        {
            this.commandInterpreter = commandInterpreter;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                IExecutable command = this.commandInterpreter.InterpretCommand(data);
                command.Execute();
                input = Console.ReadLine();
            }
        }
    }
}
