namespace MyLogger.Core
{
    using MyLogger.Appenders;
    using MyLogger.Loggers;
    using System;
    using System.Linq;

    public class Engine
    {
        private CommandInterpreter commandInterpreter;
        public Engine()
        {
            commandInterpreter = new CommandInterpreter();
        }
        public void Run()
        {
            int appendersCount = int.Parse(Console.ReadLine());
            IAppender[] appenders = new IAppender[appendersCount];
            for (int i = 0; i < appendersCount; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                IAppender appender = commandInterpreter.CreateAppender(inputArgs);
                appenders[i] = appender;
            }
            ILogger logger = new Logger(appenders);

            string[] command = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            while (command[0].ToLower() != "end")
            {
                commandInterpreter.CreateMessage(command, logger);

                command = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }
            Console.WriteLine(logger);
        }
    }
}
