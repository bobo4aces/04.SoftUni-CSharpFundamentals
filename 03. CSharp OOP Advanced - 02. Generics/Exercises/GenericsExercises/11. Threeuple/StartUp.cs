using System;
using System.Linq;

namespace _11._Threeuple
{
    class StartUp
    {
        static void Main()
        {
            string name = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                string[] inputArgs = Console.ReadLine()
                                    .Split(" ")
                                    .ToArray();

                if (i == 0)
                {
                    name = $"{inputArgs[0]} {inputArgs[1]}";
                    string adress = inputArgs[2];
                    string town = inputArgs[3];
                    PrintThreeuple(new Threeuple<string, string, string>(name, adress, town));
                }
                else if (i == 1)
                {
                    name = inputArgs[0];
                    int beerQuantity = int.Parse(inputArgs[1]);
                    bool isDrunk = inputArgs[2] == "drunk" ? true : false;
                    PrintThreeuple(new Threeuple<string, int, bool>(name, beerQuantity, isDrunk));
                }
                else
                {
                    name = inputArgs[0];
                    double bankAccount = double.Parse(inputArgs[1]);
                    string bankName = inputArgs[2];
                    PrintThreeuple(new Threeuple<string, double, string>(name, bankAccount, bankName));
                }
            }
        }


        private static void PrintTuple<T,U>(Tuple<T, U> tuple)
        {
            Console.WriteLine($"{tuple.Item1} -> {tuple.Item2}");
        }
        private static void PrintThreeuple<T, U, V>(Threeuple<T, U, V> threeuple)
        {
            Console.WriteLine($"{threeuple.Item1} -> {threeuple.Item2} -> {threeuple.Item3}");
        }

    }
}
