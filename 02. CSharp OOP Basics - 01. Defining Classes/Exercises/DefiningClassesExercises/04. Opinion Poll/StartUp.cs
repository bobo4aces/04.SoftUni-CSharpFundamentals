using System;
using System.Collections.Generic;
using System.Linq;

namespace OpinionPoll
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int personsCount = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 0; i < personsCount; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = info[0];
                int age = int.Parse(info[1]);
                Person person = new Person(name,age);
                persons.Add(person);
            }

            List<Person> result = Person.GetPersons(persons);

            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
