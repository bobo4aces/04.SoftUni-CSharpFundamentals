using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Citizen : ICitizen
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthday { get; private set; }

        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public List<Citizen> GetFakeIds(List<Citizen> citizens, char character)
        {
            return citizens.Where(c => c.Id[c.Id.Length - 1] == character).ToList();
        }
    }
}