using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmeti
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> add = l => l.Select(n=>n + 1).ToList();
            Func<List<int>, List<int>> multiply = l => l.Select(n => n * 2).ToList();
            Func<List<int>, List<int>> subtract = l => l.Select(n => n-1).ToList();
            Action<List<int>> print = l => Console.WriteLine(string.Join(" ",l));

            List<int> numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = add(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiply(numbers);
                }
                else if (command == "subtract")
                {
                    numbers = subtract(numbers);
                }
                else if (command == "print")
                {
                    print(numbers);
                }

                command = Console.ReadLine().ToLower();
            }
        }
    }
}
