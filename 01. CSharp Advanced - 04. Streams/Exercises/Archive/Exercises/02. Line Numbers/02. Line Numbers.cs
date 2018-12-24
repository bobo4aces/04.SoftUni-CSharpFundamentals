using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../../../";
            string inputFileName = "text.txt";
            string outputFileName = "output.txt";

            string inputFile = Path.Combine(path, inputFileName);
            string outputFile = Path.Combine(path, outputFileName);

            StreamReader streamReader = new StreamReader(inputFile);
            StreamWriter streamWriter = new StreamWriter(outputFile);

            using (streamReader)
            {
                using (streamWriter)
                {
                    int lineCount = 0;
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        streamWriter.WriteLine($"Line {++lineCount}: {line}");
                        line = streamReader.ReadLine();
                    }
                }
            }
        }
    }
}
