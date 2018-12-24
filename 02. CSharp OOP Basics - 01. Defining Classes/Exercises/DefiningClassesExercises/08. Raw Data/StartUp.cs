using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            ReadCars(carsCount, cars);

            string command = Console.ReadLine().ToLower();

            if (command == "fragile")
            {
                WriteFragileCargo(cars);
            }
            else if (command == "flamable")
            {
                WriteFlamableCargo(cars);
            }
        }

        private static void WriteFlamableCargo(List<Car> cars)
        {
            cars
                .Where(c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower > 250)
                .ToList()
                .ForEach(l => Console.WriteLine(l.Model));
        }

        private static void WriteFragileCargo(List<Car> cars)
        {
            cars
                .Where(c => c.Cargo.CargoType == "fragile" && c.Tires.Any(t => t.TirePressure < 1))
                .ToList()
                .ForEach(l => Console.WriteLine(l.Model));
        }

        private static void ReadCars(int carsCount, List<Car> cars)
        {
            for (int i = 0; i < carsCount; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car car = new Car(info);
                cars.Add(car);
            }
        }
    }
}
