using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Hotels
{
    public class Hotel : IHotel
    {
        private const int defaultCapacity = 10;
        private int capacity;

        public Dictionary<string, IAnimal> Animals  { get; set; }

        internal Hotel()
        {
            Capacity = defaultCapacity;
            Animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = defaultCapacity; }
        }

        public void Accommodate(IAnimal animal)
        {
            if (Capacity <= 0)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            Animals.Add(animal.Name, animal);
            Capacity--;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            Animals[animalName].Owner = owner;
            Animals[animalName].IsAdopt = true;
            Animals.Remove(animalName);
        }
    }
}
