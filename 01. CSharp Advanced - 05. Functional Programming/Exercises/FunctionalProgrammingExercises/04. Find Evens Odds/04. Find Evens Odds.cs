using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = n => n % 2 == 0;
            int[] numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string filter = Console.ReadLine();
            Console.WriteLine(string.Join(" ", Enumerable.Range(numbers[0], numbers[1] - numbers[0] + 1)
                .Where(n => filter == "even" ? isEven(n) : !isEven(n))
                .ToArray()));     
        }
    }
}
