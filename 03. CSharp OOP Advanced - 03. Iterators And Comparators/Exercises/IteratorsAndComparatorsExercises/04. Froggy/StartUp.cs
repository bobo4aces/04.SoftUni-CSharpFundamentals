using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Froggy
{
    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                                    .Split(", ")
                                    .Select(int.Parse)
                                    .ToArray();

            Lake lake = new Lake(numbers);

            List<int> result = new List<int>();

            foreach (var item in lake)
            {
                result.Add(item);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
