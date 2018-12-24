using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> isDouble = s => s.ToLower() == "double";
            Predicate<string> isStartsWith = s => s.ToLower() == "startswith";
            Predicate<string> isEndsWith = s => s.ToLower() == "endswith";
            Predicate<string> isGivenLength = s => s.ToLower() == "length";

            Func<string, bool> filter;
            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0]?.ToLower() != "party!")
            {
                if (isDouble(command[0]))
                {
                    if (isStartsWith(command[1]))
                    {
                        List<string> currentList = people.FindAll(s => s.StartsWith(command[2])).ToList();
                        people.Concat(currentList);
                    }
                    else if (isEndsWith(command[1]))
                    {
                        List<string> currentList = people.FindAll(s => s.EndsWith(command[2])).ToList();
                        people.Concat(currentList);
                    }
                    else if (isGivenLength(command[1]))
                    {
                        List<string> currentList = people.FindAll(s => s.Length == int.Parse(command[2])).ToList();
                        people.Concat(currentList);
                    }
                }
                else
                {
                    if (isStartsWith(command[1]))
                    {
                        people.RemoveAll(s => s.StartsWith(command[2]));
                    }
                    else if (isEndsWith(command[1]))
                    {
                        people.RemoveAll(s => s.EndsWith(command[2]));
                    }
                    else if (isGivenLength(command[1]))
                    {
                        people.RemoveAll(s => s.Length == int.Parse(command[2]));
                    }
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            people.RemoveAll(s=>s)
        }
    }
}
