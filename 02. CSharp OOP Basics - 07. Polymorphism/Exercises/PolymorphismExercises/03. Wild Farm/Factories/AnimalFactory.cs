using System;
using WildFarm.Models;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string[] info)
        {
            string type = info[0].ToLower();
            string name = info[1];
            double weight = double.Parse(info[2]);
            double wingSize = 0;
            string livingRegion = string.Empty;
            string breed = string.Empty;
            switch (type)
            {
                case "owl":
                    wingSize = double.Parse(info[3]);
                    return new Owl(name, weight, wingSize);
                case "hen":
                    wingSize = double.Parse(info[3]);
                    return new Hen(name, weight, wingSize);
                case "mouse":
                    livingRegion = info[3];
                    return new Mouse(name, weight,livingRegion);
                case "dog":
                    livingRegion = info[3];
                    return new Dog(name, weight, livingRegion);
                case "cat":
                    livingRegion = info[3];
                    breed = info[4];
                    return new Cat(name, weight, livingRegion, breed);
                case "tiger":
                    livingRegion = info[3];
                    breed = info[4];
                    return new Tiger(name, weight, livingRegion, breed);
                default:
                    throw new ArgumentException("Invalid Animal");
            }
        }
    }
}
