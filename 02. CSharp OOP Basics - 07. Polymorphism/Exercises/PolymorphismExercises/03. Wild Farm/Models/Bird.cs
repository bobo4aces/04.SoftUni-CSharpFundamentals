using System;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public abstract class Bird : Animal, IBird
    {
        private double wingSize;

        public double WingSize
        {
            get { return wingSize; }
            set { wingSize = value; }
        }


        public Bird(string name, double weight, double wingSize)
            :base(name, weight)
        {
            WingSize = wingSize;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Producing Sound");
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
