using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Strtg_Pattern
{
    public class StartUp
    {
        public static void Main()
        {
            SortedSet<Person> nameComparisonList = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> ageComparisonList = new SortedSet<Person>(new AgeComparator());

            int personsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < personsCount; i++)
            {
                string[] inputArgs = Console.ReadLine()
                                        .Split(" ")
                                        .ToArray();

                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);

                Person person = new Person(name, age);

                nameComparisonList.Add(person);
                ageComparisonList.Add(person);
            }

            foreach (var person in nameComparisonList)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }

            foreach (var person in ageComparisonList)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}
