using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Problem_3
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            string wordsSourceFile = @"C:\Users\Bo\Desktop\SoftUni\C Sharp Fundamentals\C Sharp Advanced\04. Streams\Homeworks\1\Streams\files\words.txt";
            string textSourceFile = @"C:\Users\Bo\Desktop\SoftUni\C Sharp Fundamentals\C Sharp Advanced\04. Streams\Homeworks\1\Streams\files\text.txt";
            string destinationPath = @"C:\Users\Bo\Desktop\SoftUni\C Sharp Fundamentals\C Sharp Advanced\04. Streams\Homeworks\1\Streams\files\result.txt";

            using (StreamReader reader = new StreamReader(wordsSourceFile))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();

                    if(words.ContainsKey(line) == false)
                    {
                        words.Add(line, 0);
                    }

                    line = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader(textSourceFile))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();

                    Regex regex = new Regex("[A-Za-z]+");

                    foreach (Match item in regex.Matches(line))
                    {
                        if (words.ContainsKey(item.Value))
                        {
                            words[item.Value] += 1;
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(destinationPath))
            {
                foreach (var item in words.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
