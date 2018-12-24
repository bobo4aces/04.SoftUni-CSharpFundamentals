using System;
using WildFarm.Models;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string[] info)
        {
            string foodType = info[0].ToLower();
            int quantity = int.Parse(info[1]);

            switch (foodType)
            {
                case "vegetable":
                    return new Vegetable(quantity);
                case "fruit":
                    return new Fruit(quantity);
                case "meat":
                    return new Meat(quantity);
                case "seeds":
                    return new Seeds(quantity);
                default:
                    throw new ArgumentException("Invalid food!");
            }
        }
    }
}
