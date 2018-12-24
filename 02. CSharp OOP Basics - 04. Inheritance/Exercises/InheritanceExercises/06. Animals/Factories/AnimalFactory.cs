using System;
using Animals.Animals;

namespace Animals
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string animalType, string name, int age, string gender)
        {
            switch (animalType.ToLower())
            {
                case "cat":
                    return new Cat(name, age, gender);
                case "dog":
                    return new Dog(name, age, gender);
                case "frog":
                    return new Frog(name, age, gender);
                case "kitten":
                    return new Kitten(name, age, gender);
                case "tomcat":
                    return new Tomcat(name, age, gender);
                default:
                    throw new ArgumentException("Invalid input!");
            }
        }
    }
}
