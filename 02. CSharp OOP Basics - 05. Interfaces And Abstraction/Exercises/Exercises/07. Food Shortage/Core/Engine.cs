using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodShortage.Core
{
    public class Engine
    {
        public void Run()
        {
            int peopleCount = int.Parse(Console.ReadLine());

            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            int purchasedFood = 0;
            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input.Length == 4)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    citizens.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    Rebel rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    rebels.Add(rebel);
                }
            }

            string name = Console.ReadLine();
            while (name.ToLower() != "end")
            {
                rebels.FirstOrDefault(r => r.Name == name)?.BuyFood();
                citizens.FirstOrDefault(c => c.Name == name)?.BuyFood();

                name = Console.ReadLine();
            }
            purchasedFood += rebels.Sum(r => r.Food);
            purchasedFood += citizens.Sum(c => c.Food);
            Console.WriteLine(purchasedFood);
        }
    }
}
