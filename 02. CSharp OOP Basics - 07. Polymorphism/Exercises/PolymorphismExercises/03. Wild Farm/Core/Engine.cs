using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Contracts;
using WildFarm.Factories;

namespace WildFarm.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] info = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            bool isOddLine = false;
            FoodFactory foodFactory = new FoodFactory();
            ICollection<IFood> foods = new List<IFood>();

            AnimalFactory animalFactory = new AnimalFactory();
            
            ICollection<IAnimal> animals = new List<IAnimal>();

            while (info[0]?.ToLower() != "end")
            {
                if (isOddLine)
                {
                    isOddLine = false;
                    IFood food = foodFactory.CreateFood(info);
                    IAnimal animal = animals.Last();
                    try
                    {
                        animal.Eat(food);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
                else
                {
                    isOddLine = true;
                    IAnimal animal = animalFactory.CreateAnimal(info);
                    animal.ProduceSound();
                    animals.Add(animal);
                }

                info = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
