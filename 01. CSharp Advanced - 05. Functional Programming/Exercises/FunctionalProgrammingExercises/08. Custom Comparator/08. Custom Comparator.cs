using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> customSort = sortEvenFirst;
            Array.Sort(numbers, (a, b) => customSort(a, b));
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int sortEvenFirst(int x, int y)
        {
            if (Math.Abs(x % 2) == Math.Abs(y % 2))
            {
                if (x == y)
                {
                    return 0;
                }
                else if (x < y)
                {
                    return -1;
                }
                return 1;
            }
            else
            {
                if (Math.Abs(x % 2) == 0)
                {
                    return -1;
                }
                return 1;
            }
        }
    }
}
