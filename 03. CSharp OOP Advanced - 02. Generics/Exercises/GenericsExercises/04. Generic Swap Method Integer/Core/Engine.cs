using _04._Generic_Swap_Method_Integer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Generic_Swap_Method_Integer.Core
{
    public class Engine
    {
        public void Run()
        {
            int stringsCount = int.Parse(Console.ReadLine());
            IList<Box<int>> list = new List<Box<int>>();
            
            for (int i = 0; i < stringsCount; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                list.Add(box);
            }
            int[] indexes = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            list = Box<int>.Swap(list, indexes[0], indexes[1]);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
