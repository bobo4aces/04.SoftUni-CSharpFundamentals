using System;
using System.IO;

namespace _01._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../../../";
            string fileName = "text.txt";

            string file = Path.Combine(path, fileName);

            StreamReader streamReader = new StreamReader(file);

            using (streamReader)
            {
                int lineCount = 0;
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    if (lineCount % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    line = streamReader.ReadLine();
                    lineCount++;
                }
            }
        }
    }
}
