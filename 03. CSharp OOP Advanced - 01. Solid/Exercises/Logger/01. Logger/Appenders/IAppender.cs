namespace MyLogger.Appenders
{
    using MyLogger.Enums;
    using MyLogger.Layouts;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void AppendMessage(string dateTime, ReportLevel reportLevel, string message);
    }
}
