using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main()
        {
            int countOfLines = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < countOfLines; i++)
            {
                Car currentCar = new Car(Console.ReadLine);
                cars.Add(currentCar);
            }

            var command = Console.ReadLine();

            cars
                .Where(c => c.isCarSuitale(command))
                .ToList()
                .ForEach(c => Console.WriteLine(c.Model));
        }
    }
}
