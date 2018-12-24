using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> colorClothesCount = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input.Length < 2)
                {
                    continue;
                }

                string color = input[0];

                string[] currentClothes = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!colorClothesCount.ContainsKey(color))
                {
                    colorClothesCount.Add(color, new Dictionary<string, int>());
                }
                for (int j = 0; j < currentClothes.Length; j++)
                {
                    if (!colorClothesCount[color].ContainsKey(currentClothes[j]))
                    {
                        colorClothesCount[color].Add(currentClothes[j], 0);
                    }
                    colorClothesCount[color][currentClothes[j]]++;
                }
                
            }

            string[] lookupData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            string lookupColor = lookupData[0];
            string lookupCloth = lookupData[1];

            foreach (var color in colorClothesCount)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == lookupColor && cloth.Key == lookupCloth)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
