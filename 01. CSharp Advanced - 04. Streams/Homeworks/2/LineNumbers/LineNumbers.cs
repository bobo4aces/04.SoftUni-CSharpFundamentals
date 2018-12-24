using System;
using System.IO;

namespace OddLines
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"../../../../Files/text.txt"))
            {
                var line = ""; var count = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"Line{++count}: {line}");
                }
            }
        }
    }
}
