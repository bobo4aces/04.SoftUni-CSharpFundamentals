namespace MyLogger.Loggers
{
    using System.Collections.Generic;
    using System.Text;
    using MyLogger.Appenders;
    using MyLogger.Enums;

    public class Logger : ILogger
    {
        public ICollection<IAppender> Appenders { get; private set; } = new List<IAppender>();

        public Logger(IAppender appender)
        {
            Appenders.Add(appender);
        }

        public Logger(ICollection<IAppender> appenders)
        {
            Appenders = appenders;
        }

        public void Critical(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.AppendMessage(dateTime, ReportLevel.CRITICAL, message);
            }
        }

        public void Error(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.AppendMessage(dateTime, ReportLevel.ERROR, message);
            }
        }

        public void Fatal(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.AppendMessage(dateTime, ReportLevel.FATAL, message);
            }
        }

        public void Info(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.AppendMessage(dateTime, ReportLevel.INFO, message);
            }
        }

        public void Warning(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.AppendMessage(dateTime, ReportLevel.WARNING, message);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Logger info");
            foreach (var appender in Appenders)
            {
                stringBuilder.AppendLine($"{appender}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
