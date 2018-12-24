using System;
using System.IO;

namespace _02.Problem_2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string pathSourceFile = @"C:\Users\Bo\Desktop\SoftUni\C Sharp Fundamentals\C Sharp Advanced\04. Streams\Homeworks\1\Streams\files\text.txt";
            string destinationPath = @"C:\Users\Bo\Desktop\SoftUni\C Sharp Fundamentals\C Sharp Advanced\04. Streams\Homeworks\1\Streams\files\output.txt";

            using (StreamReader reader = new StreamReader(pathSourceFile))
            {
                using (StreamWriter writer = new StreamWriter(destinationPath))
                {
                    string line = reader.ReadLine();

                    int counter = 1;

                    while (line != null)
                    {
                        writer.WriteLine($"Line {counter++}:{line}");

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
