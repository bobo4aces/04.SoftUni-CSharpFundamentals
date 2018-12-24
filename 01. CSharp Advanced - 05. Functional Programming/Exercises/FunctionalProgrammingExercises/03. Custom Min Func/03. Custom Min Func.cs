using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Custom_Min_Func
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> findSmallestNumber = l => l.Min();
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(findSmallestNumber(numbers));
        }
    }
}
