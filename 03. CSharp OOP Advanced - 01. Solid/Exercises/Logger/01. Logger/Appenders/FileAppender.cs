namespace MyLogger.Appenders
{
    using MyLogger.Enums;
    using MyLogger.Layouts;
    using MyLogger.LogFiles;
    using System;

    public class FileAppender : Appender
    {
        private ILayout layout;
        public ILogFile File { get; set; }

        public FileAppender(ILayout layout)
            : base(layout)
        {
            this.layout = layout;
        }

        public FileAppender(ILayout layout, ILogFile file) 
            : base(layout)
        {
            this.layout = layout;
            this.File = file;
        }

        public override void AppendMessage(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                string line = String.Format(layout.Format, dateTime, reportLevel, message);
                File.Write(line);
                this.MessagesCount++;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}
