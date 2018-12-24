using FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Citizen : ICitizen, IBuyer
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthday { get; private set; }
        public int Food { get; set; } = 0;

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

        public void BuyFood()
        {
            Food += 10;
        }
    }
}