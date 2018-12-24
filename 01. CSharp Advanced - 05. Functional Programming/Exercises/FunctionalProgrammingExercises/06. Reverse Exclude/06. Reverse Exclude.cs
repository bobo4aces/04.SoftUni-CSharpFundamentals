using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int element = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = n => n % element == 0;
            Action<List<int>> reverseArray = a => a.Reverse();
            Func<List<int>, List<int>> removeElements = a => a.Where(n => !isDivisible(n)).ToList();

            reverseArray(numbers);

            Console.WriteLine(string.Join(" ", removeElements(numbers)));
        }
    }
}
