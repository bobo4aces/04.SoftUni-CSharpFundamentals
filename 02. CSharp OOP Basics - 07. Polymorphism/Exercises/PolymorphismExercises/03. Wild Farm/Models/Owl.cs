using System;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Owl : Bird, IBird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                Weight += 0.25 * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
