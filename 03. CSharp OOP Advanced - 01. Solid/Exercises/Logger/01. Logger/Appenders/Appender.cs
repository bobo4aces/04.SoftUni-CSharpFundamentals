namespace MyLogger.Appenders
{
    using MyLogger.Enums;
    using MyLogger.Layouts;

    public abstract class Appender : IAppender
    {
        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; protected set; }

        public Appender(ILayout layout)
        {
            Layout = layout;
            ReportLevel = ReportLevel.INFO;
            MessagesCount = 0;
        }

        public abstract void AppendMessage(string dateTime, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, " +
                   $"Layout type: {this.Layout.GetType().Name}, " +
                   $"Report level: {this.ReportLevel}, " +
                   $"Messages appended: {this.MessagesCount}";
        }
    }
}
