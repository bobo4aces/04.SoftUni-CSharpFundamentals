using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int chemicalCompoundsCount = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalCompounds = new SortedSet<string>();

            for (int i = 0; i < chemicalCompoundsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var item in input)
                {
                    chemicalCompounds.Add(item);
                }
            }

            foreach (var chemicalCompound in chemicalCompounds)
            {
                Console.Write(chemicalCompound + " ");
            }
            Console.WriteLine();
        }
    }
}
