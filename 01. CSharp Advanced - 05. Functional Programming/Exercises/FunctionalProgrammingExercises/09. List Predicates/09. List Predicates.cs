using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int rangeEndNumber = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int, int[], bool> isDivisible = CheckNumber;
            List<int> numbers = new List<int>();
            for (int i = 1; i <= rangeEndNumber; i++)
            {
                if (isDivisible(i, dividers))
                {
                    numbers.Add(i);
                }
                
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool CheckNumber(int number, int[] numbers)
        {
            foreach (var num in numbers)
            {
                if (number % num != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
