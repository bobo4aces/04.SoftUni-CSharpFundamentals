using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    public class StartUp
    {
        static void Main()
        {
            string[] command = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<Person> persons = new List<Person>();

            while (command[0]?.ToLower() != "end")
            {
                string currentName = command[0];
                if (!persons.Any(p => p.Name == currentName))
                {
                    Person person = new Person(currentName);
                    persons.Add(person);
                }
                switch (command[1]?.ToLower())
                {
                    case "company":
                        AddCompany(command, persons, currentName);
                        break;
                    case "pokemon":
                        AddPokemon(command, persons, currentName);
                        break;
                    case "parents":
                        AddParents(command, persons, currentName);
                        break;
                    case "children":
                        AddChildren(command, persons, currentName);
                        break;
                    case "car":
                        AddCar(command, persons, currentName);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)

                .ToArray();
            }

            string personToPrint = Console.ReadLine();

            Person output = persons.Where(p => p.Name == personToPrint).FirstOrDefault();

            Console.WriteLine(output);
        }

        private static void AddCar(string[] command, List<Person> persons, string currentName)
        {
            Car car = new Car(command[2], int.Parse(command[3]));
            persons
                .Where(p => p.Name == currentName)
                .First()
                .Car=car;
        }

        private static void AddChildren(string[] command, List<Person> persons, string currentName)
        {
            Children children = new Children(command[2], command[3]);
            persons
                .Where(p => p.Name == currentName)
                .First()
                .Children
                .Add(children);
        }

        private static void AddParents(string[] command, List<Person> persons, string currentName)
        {
            Parents parents = new Parents(command[2], command[3]);
            persons
                .Where(p => p.Name == currentName)
                .First()
                .Parents
                .Add(parents);
        }

        private static void AddPokemon(string[] command, List<Person> persons, string currentName)
        {
            Pokemon pokemon = new Pokemon(command[2], command[3]);
            persons
                .Where(p => p.Name == currentName)
                .First()
                .Pokemons
                .Add(pokemon);
        }

        private static void AddCompany(string[] command, List<Person> persons, string currentName)
        {
            Company company = new Company(command[2], command[3], decimal.Parse(command[4]));
            persons
                .Where(p => p.Name == currentName)
                .First()
                .Company=company;
        }
    }
}
