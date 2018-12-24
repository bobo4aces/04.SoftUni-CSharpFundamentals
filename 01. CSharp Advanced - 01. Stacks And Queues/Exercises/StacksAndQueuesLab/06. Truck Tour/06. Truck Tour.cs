using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<int> pumps = new Queue<int>();

            for (int i = 0; i < pumpsCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                int petrol = input[0];
                int distance = input[1];

                pumps.Enqueue(petrol - distance);
            }

            for (int i = 0; i < pumpsCount; i++)
            {
                int fuelLeft = 0;
                foreach (var fuel in pumps)
                {
                    fuelLeft += fuel;
                    if (fuelLeft < 0)
                    {
                        break;
                    }
                }

                if (fuelLeft >= 0)
                {
                    Console.WriteLine(i);
                    return;
                }
                pumps.Enqueue(pumps.Dequeue());
            }
        }
    }
}
