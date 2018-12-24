using _03._Generic_Swap_Method_String.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Generic_Swap_Method_String.Core
{
    public class Engine
    {
        public void Run()
        {
            int stringsCount = int.Parse(Console.ReadLine());
            IList<Box<string>> list = new List<Box<string>>();
            
            for (int i = 0; i < stringsCount; i++)
            {
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                list.Add(box);
            }
            int[] indexes = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            list = Box<string>.Swap(list, indexes[0], indexes[1]);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
