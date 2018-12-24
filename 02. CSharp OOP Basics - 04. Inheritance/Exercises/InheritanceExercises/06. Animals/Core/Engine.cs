using Animals.Animals;
using System;
using System.Linq;

namespace Animals
{
    public class Engine
    {
        private AnimalFactory animalFactory;

        public Engine()
        {
            this.animalFactory = new AnimalFactory();
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input.ToLower() != "beast!")
            {
                try
                {
                    string animalType = input;
                    string[] animalInfo = Console.ReadLine()
                                            .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                            .ToArray();
                    Animal animal = animalFactory.CreateAnimal(
                                                    animalType,
                                                    animalInfo[0],
                                                    int.Parse(animalInfo[1]),
                                                    animalInfo[2]);
                    Console.WriteLine(animal);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                input = Console.ReadLine();
            }
        }
    }
}
