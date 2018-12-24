using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ExerciseStreams

{
    class WordCount
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            var words1 = new List<string>();
            var words2 = new List<string>();

            using (StreamReader reader = new StreamReader(@"../../../../Files/text.txt"))
            {
                words1 = reader.ReadToEnd()
                    .Split(new char[] { ' ', '-', '.', ',', '!', '?', '\r', '\n' }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToLower())
                    .ToList();
            }
            using (StreamReader reader = new StreamReader(@"../../../../Files/words.txt"))
            {
                words2 = reader.ReadToEnd()
                    .Split(new char[] { ' ', '\n', '\r' }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToLower())
                    .ToList();
            }
            foreach (var word in words1)
            {
                if (words2.Contains(word))
                {
                    if (!dict.ContainsKey(word)) dict.Add(word, 1);
                    else dict[word]++;
                }
            }
            foreach (var item in dict.OrderByDescending(x => x.Value)) Console.WriteLine($"{item.Key} - {item.Value}");
        }
    }
}
