using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<KeyValuePair<string, int>> namesAndAges = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] nameAndAge = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = nameAndAge[0];
                int age = int.Parse(nameAndAge[1]);
                namesAndAges.Add(new KeyValuePair<string, int>(name, age));
            }
            
            string condition = Console.ReadLine();
            int ageLimit = int.Parse(Console.ReadLine());

            Func<int, bool> tester = CreateTester(condition, ageLimit);
            string format = Console.ReadLine();
            Action <KeyValuePair<string,int>> printer = CreatePrinter(format);

            PrintFilteredStudents(namesAndAges, tester, printer);
        }

        private static void PrintFilteredStudents(List<KeyValuePair<string, int>> namesAndAges, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var name in namesAndAges)
            {
                if (tester(name.Value))
                {
                    printer(name);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return n => Console.WriteLine(n.Key);
                case "age":
                    return a => Console.WriteLine(a.Value);
                case "name age":
                    return p => Console.WriteLine($"{p.Key} - {p.Value}");
                default:
                    return null;
            }
        }

        private static Func<int, bool> CreateTester(string condition, int ageLimit)
        {
            switch (condition)
            {
                case "younger":
                    return a => a < ageLimit;
                case "older":
                    return a => a >= ageLimit;
                default:
                    return null;
            }
        }
    }
}
