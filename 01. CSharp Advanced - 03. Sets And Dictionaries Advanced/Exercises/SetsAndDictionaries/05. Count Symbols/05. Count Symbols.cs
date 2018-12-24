using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> lettersCount = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!lettersCount.ContainsKey(text[i]))
                {
                    lettersCount.Add(text[i], 0);
                }
                lettersCount[text[i]]++;
            }

            foreach (var letter in lettersCount)
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
