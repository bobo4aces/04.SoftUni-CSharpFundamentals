using System;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private double weight;
        private int foodEaten;
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        
        public virtual void Eat(IFood food)
        {
            FoodEaten += food.Quantity;
        }

        public void NotEatable(IFood food)
        {
            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
        }

        public virtual void ProduceSound()
        {
            Console.WriteLine("Producing Sound");
        }
    }
}
