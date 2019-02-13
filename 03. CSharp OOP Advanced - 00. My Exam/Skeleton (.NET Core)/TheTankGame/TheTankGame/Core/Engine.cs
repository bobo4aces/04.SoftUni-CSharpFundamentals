namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;
            while (this.isRunning)
            {
                IList<string> input = this.reader.ReadLine().Split(" ").ToList();
                string terminate = input[0];
                string output = this.commandInterpreter.ProcessInput(input);
                
                if (terminate == "Terminate")
                {
                    this.isRunning = false;
                }
                this.writer.WriteLine(output);
            }
            
        }
    }
}