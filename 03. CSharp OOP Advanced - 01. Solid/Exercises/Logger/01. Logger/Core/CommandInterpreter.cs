namespace MyLogger.Core
{
    using MyLogger.Appenders;
    using MyLogger.Enums;
    using MyLogger.Layouts;
    using MyLogger.LogFiles;
    using MyLogger.Loggers;
    using System;

    public class CommandInterpreter
    {
        private IAppender appender;

        public IAppender CreateAppender(string[] inputArgs)
        {
            string appenderTypeAsText = inputArgs[0].ToLower();
            string layoutTypeAsText = inputArgs[1].ToLower();
            ILayout layout = GetLayout(layoutTypeAsText);
            appender = GetAppender(appenderTypeAsText, layout);
            if (inputArgs.Length == 3)
            {
                string reportLevelAsText = inputArgs[2].ToUpper();
                appender.ReportLevel = Enum.Parse<ReportLevel>(reportLevelAsText);
            }
            return appender;
        }

        public IAppender CreateMessage(string[] inputArgs,ILogger logger)
        {
            string reportLevelAsText = inputArgs[0].ToUpper();
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(reportLevelAsText);
            string dateTime = inputArgs[1];
            string message = inputArgs[2];
            foreach (var appender in logger.Appenders)
            {
                appender.AppendMessage(dateTime, reportLevel, message);
            }
            return appender;
        }

        private static IAppender GetAppender(string appenderTypeAsText, ILayout layout)
        {
            IAppender appender;
            switch (appenderTypeAsText)
            {
                case "consoleappender":
                    appender = new ConsoleAppender(layout);
                    break;
                case "fileappender":
                    ILogFile logFile = new LogFile();
                    appender = new FileAppender(layout, logFile);
                    break;
                default:
                    throw new ArgumentException("Invalid appender!");
            }

            return appender;
        }

        private static ILayout GetLayout(string layoutTypeAsText)
        {
            ILayout layout;
            switch (layoutTypeAsText)
            {
                case "simplelayout":
                    layout = new SimpleLayout();
                    break;
                case "xmllayout":
                    layout = new XmlLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid layout!");
            }

            return layout;
        }
    }
}
