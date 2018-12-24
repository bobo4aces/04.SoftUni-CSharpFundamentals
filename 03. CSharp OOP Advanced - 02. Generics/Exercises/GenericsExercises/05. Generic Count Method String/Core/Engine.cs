using _05._Generic_Count_Method_String.Entities;
using System;
using System.Collections.Generic;

namespace _05._Generic_Count_Method_String.Core
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
            string elementToCompare = Console.ReadLine();
            Box<string> boxToCompare = new Box<string>(elementToCompare);
            int count = Box<string>.GetGreaterElementsCount(list, boxToCompare);
            Console.WriteLine(count);
        }
    }
}
