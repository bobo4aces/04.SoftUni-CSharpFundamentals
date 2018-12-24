using _06._Generic_Count_Method_Double.Entities;
using System;
using System.Collections.Generic;

namespace _06._Generic_Count_Method_Double.Core
{
    public class Engine
    {
        public void Run()
        {
            int stringsCount = int.Parse(Console.ReadLine());
            IList<Box<double>> list = new List<Box<double>>();
            for (int i = 0; i < stringsCount; i++)
            {
                double input = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>(input);
                list.Add(box);
            }
            double elementToCompare = double.Parse(Console.ReadLine());
            Box<double> boxToCompare = new Box<double>(elementToCompare);
            int count = Box<double>.GetGreaterElementsCount(list, boxToCompare);
            Console.WriteLine(count);
        }
    }
}
