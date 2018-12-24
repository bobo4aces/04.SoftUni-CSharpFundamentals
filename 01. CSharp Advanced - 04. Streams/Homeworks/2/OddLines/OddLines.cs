using System;
using System.IO;

namespace ExerciseStreams
{
    class OddLines
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"../../../../Files/text.txt"))
            {
                var line = ""; var count = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (++count % 2 == 0) Console.WriteLine(line);
                }
            }
        }
    }
}
