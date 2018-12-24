namespace MyLogger.Appenders
{
    using System;
    using MyLogger.Enums;
    using MyLogger.Layouts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void AppendMessage(string dateTime, ReportLevel reportLevel, string message)
        {
            if (ReportLevel <= reportLevel)
            {
                string line = String.Format(this.Layout.Format, dateTime, reportLevel, message);
                Console.WriteLine(line);
                MessagesCount++;
            }
        }
    }
}
