using System;
using System.Linq;

namespace _10._Tuple
{
    class StartUp
    {
        static void Main()
        {
            string name = string.Empty;
            string adress = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                string[] inputArgs = Console.ReadLine()
                                    .Split(" ")
                                    .ToArray();

                if (i == 0)
                {
                    name = $"{inputArgs[0]} {inputArgs[1]}";
                    adress = inputArgs[2];
                    PrintTuple(new Tuple<string, string>(name, adress));
                }
                else if (i == 1)
                {
                    name = inputArgs[0];
                    int beerQuantity = int.Parse(inputArgs[1]);
                    PrintTuple(new Tuple<string, int>(name, beerQuantity));
                }
                else
                {
                    int integerValue = int.Parse(inputArgs[0]);
                    double doubleValue = double.Parse(inputArgs[1]);
                    PrintTuple(new Tuple<int, double>(integerValue, doubleValue));
                }
            }
        }


        private static void PrintTuple<T,U>(Tuple<T, U> tuple)
        {
            Console.WriteLine($"{tuple.Item1} -> {tuple.Item2}");
        }
    }
}
