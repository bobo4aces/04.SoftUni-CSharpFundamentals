using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regulars = new HashSet<string>();
            HashSet<string> vips = new HashSet<string>();

            string input = Console.ReadLine();

            while (input?.ToLower() != "party")
            {
                if (input.Length == 8)
                {
                    if (Char.IsDigit(input[0]))
                    {
                        vips.Add(input);
                    }
                    else
                    {
                        regulars.Add(input);
                    }
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input?.ToLower() != "end")
            {
                if (input.Length == 8)
                {
                    if (Char.IsDigit(input[0]))
                    {
                        vips.Remove(input);
                    }
                    else
                    {
                        regulars.Remove(input);
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(regulars.Count + vips.Count);

            foreach (var vip in vips)
            {
                Console.WriteLine(vip);
            }

            foreach (var regular in regulars)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
