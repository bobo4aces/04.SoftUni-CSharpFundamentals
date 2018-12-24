using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printSir = n => Console.WriteLine("Sir " + n);

            Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(n => printSir(n));
        }
    }
}
