namespace MyLogger.LogFiles
{
    using System;
    using System.IO;
    using System.Linq;

    public class LogFile : ILogFile
    {
        private const string path = "../../../log.txt";

        public LogFile()
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            fileStream.Close();
        }

        public int Size
        {
            get
            {
                using (StreamReader streamReader = new StreamReader(path, true))
                {
                    char[] allText = streamReader.ReadToEnd().ToCharArray();
                    int totalSize = allText
                               .Where(Char.IsLetter)
                               .Sum(c => c);
                    return totalSize;
                }
            }
        }

        public void Write(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine(message);
            }            
        }
    }
}
