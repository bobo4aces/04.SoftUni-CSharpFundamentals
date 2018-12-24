using System;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Hen : Bird, IBird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            Weight += 0.35 * food.Quantity;
            FoodEaten += food.Quantity;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
