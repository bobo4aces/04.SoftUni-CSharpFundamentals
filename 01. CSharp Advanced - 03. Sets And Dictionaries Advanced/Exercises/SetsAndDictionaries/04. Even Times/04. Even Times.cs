using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbersAndAppearances = new Dictionary<int, int>();
            
            for (int i = 0; i < numbersCount; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
            
                if (!numbersAndAppearances.ContainsKey(currentNumber))
                {
                    numbersAndAppearances.Add(currentNumber, 0);
                }
                numbersAndAppearances[currentNumber]++;
            }

            foreach (var number in numbersAndAppearances)
            {
                if (number.Value % 2 == 0)
                {
                    Console.WriteLine(number.Key);
                }
            }
        }
    }
}
