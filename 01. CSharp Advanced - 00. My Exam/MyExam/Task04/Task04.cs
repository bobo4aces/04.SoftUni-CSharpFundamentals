using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Task04
{
    class Task04
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] filledBottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> cups = new Stack<int>(cupsCapacity.Reverse());
            Queue<int> bottles = new Queue<int>(filledBottles.Reverse());

            int wastedWater = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Peek();
                int currentBottle = bottles.Peek();
                int difference = currentBottle - currentCup;
                if (currentCup - currentBottle <= 0)
                {
                    cups.Pop();
                    wastedWater += Math.Abs(difference);
                    bottles.Dequeue();
                }
                else
                {
                    cups.Push(cups.Pop() - currentBottle);
                    bottles.Dequeue();
                }
            }
            if (bottles.Count != 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
            }
            if (cups.Count != 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
