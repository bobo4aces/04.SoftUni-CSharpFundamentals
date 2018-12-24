using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int plantsCount = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] days = new int[plants.Length];
            Stack<int> indexes = new Stack<int>();
            indexes.Push(0);

            for (int i = 1; i < plants.Length; i++)
            {
                int maxDays = 0;
                while (indexes.Count() > 0 && plants[indexes.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[indexes.Pop()]);
                }
                if (indexes.Count > 0)
                {
                    days[i] = maxDays + 1;
                }
                indexes.Push(i);
            }
            Console.WriteLine(days.Max());

        }
    }
}
