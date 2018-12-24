using System;
using System.IO;

namespace _01.Problem_1
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (StreamReader stream = new StreamReader(@"C:\Users\Bo\Desktop\SoftUni\C Sharp Fundamentals\C Sharp Advanced\04. Streams\Homeworks\1\Streams\files\text.txt"))
            {
                var line = stream.ReadLine();

                int counter = 0;

                while (line != null)
                {
                    if(counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    counter++;

                    line = stream.ReadLine();
                }
            }
            
        }
    }
}
