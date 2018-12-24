using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int membersCount = int.Parse(Console.ReadLine());
        Family family = new Family();
        for (int i = 0; i < membersCount; i++)
        {
            string[] currentPerson = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string name = currentPerson[0];
            int age = int.Parse(currentPerson[1]);
            Person person = new Person(name, age);
            family.AddMember(person);
        }
        Person oldestPerson = family.GetOldestMember();

        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}
