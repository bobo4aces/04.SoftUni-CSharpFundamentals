using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> numbersAndCount = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!numbersAndCount.ContainsKey(input[i]))
                {
                    numbersAndCount.Add(input[i], 0);
                }
                numbersAndCount[input[i]]++;
            }

            foreach (var item in numbersAndCount)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
