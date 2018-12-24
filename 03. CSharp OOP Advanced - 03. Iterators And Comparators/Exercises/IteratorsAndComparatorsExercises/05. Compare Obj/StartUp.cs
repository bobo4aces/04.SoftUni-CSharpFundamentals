using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Compare_Obj
{
    public class StartUp
    {
        public static void Main()
        {
            string[] inputArgs = Console.ReadLine()
                                        .Split(" ")
                                        .ToArray();
            List<Person> persons = new List<Person>();

            while (inputArgs[0]?.ToLower() != "end")
            {
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                string town = inputArgs[2];

                Person person = new Person(name, age, town);
                persons.Add(person);

                inputArgs = Console.ReadLine()
                                        .Split(" ")
                                        .ToArray();
            }

            int position = int.Parse(Console.ReadLine());
            int equalPeopleCount = 0;

            foreach (var person in persons)
            {
                if (person.CompareTo(persons[position-1]) == 0)
                {
                    equalPeopleCount++;
                }
            }

            if (equalPeopleCount > 1)
            {
                Console.WriteLine($"{equalPeopleCount} {persons.Count - equalPeopleCount} {persons.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
