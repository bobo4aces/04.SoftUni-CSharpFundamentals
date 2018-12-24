using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();

            string[] input = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0]?.ToLower() != "end")
            {
                if (input[0]?.ToLower() == "in")
                {
                    parkingLot.Add(input[1]);
                }
                else
                {
                    parkingLot.Remove(input[1]);
                }

                input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var numberPlate in parkingLot)
                {
                    Console.WriteLine(numberPlate);
                }
            }
        }
    }
}
