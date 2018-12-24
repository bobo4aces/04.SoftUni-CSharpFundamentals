using System;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Cat : Feline, IFeline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Meat)
            {
                Weight += 0.30 * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
