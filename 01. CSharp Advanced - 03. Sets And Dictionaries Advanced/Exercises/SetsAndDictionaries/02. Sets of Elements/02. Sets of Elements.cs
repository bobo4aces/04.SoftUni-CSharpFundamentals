using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < lengths[0] + lengths[1]; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (i < lengths[0])
                {
                    firstSet.Add(currentNumber);
                }
                else
                {
                    secondSet.Add(currentNumber);
                }
            }

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
