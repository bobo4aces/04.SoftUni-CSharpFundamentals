using System;
using System.Collections.Generic;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int namesCount = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < namesCount; i++)
            {
                string input = Console.ReadLine();
                names.Add(input);
            }


            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
