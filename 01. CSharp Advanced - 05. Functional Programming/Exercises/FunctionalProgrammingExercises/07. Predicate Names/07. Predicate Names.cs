using System;
using System.Linq;

namespace _07._Predicate_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Predicate<string> condition = l => l.Length <= nameLength;
            Func<string[], string[]> outputNames = e => e.Where(n => condition(n)).ToArray();
            Action<string[]> print = a => Console.WriteLine(string.Join("\n",a));
            print(outputNames(names));
        }
    }
}
