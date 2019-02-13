using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using FestivalManager.Entities.Contracts;
    using IO.Contracts;
    
	public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;
        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }
		public void Run()
		{
			while (true)
			{
                var input = this.reader.ReadLine();
                var result = string.Empty;

                if (input == "END")
                {
                    break;
                }
				try
				{
					result = this.ProcessCommand(input);
				}
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        result = "ERROR: " + ex.InnerException.Message;
                    }
                    else
                    {
                        result = "ERROR: " + ex.Message;
                    }
                }
                this.writer.WriteLine(result);
            }

			var report = this.festivalCоntroller.ProduceReport().TrimEnd();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(report);
		}

		public string ProcessCommand(string input)
		{
			var commandArgs = input.Split(" ").ToArray();

			var command = commandArgs[0];
			var commandParams = commandArgs.Skip(1).ToArray();

			if (command == "LetsRock")
			{
				var sets = this.setCоntroller.PerformSets();
				return sets;
			}

			var festivalControlFunction = this.festivalCоntroller.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == command);

			string output = (string)festivalControlFunction.Invoke(this.festivalCоntroller, new object[] { commandParams });

			return output;
		}
    }
}