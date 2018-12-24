using System;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Feline : Mammal, IFeline
    {
        private string breed;

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }


        public Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
