using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            AddCars(carsCount, cars);

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0]?.ToLower() != "end")
            {
                DriveCar(cars, command);

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        private static void DriveCar(List<Car> cars, string[] command)
        {
            if (command[0]?.ToLower() == "drive")
            {
                string currentModel = command[1];
                int currentDistance = int.Parse(command[2]);
                if (cars.Any(c => c.Model == currentModel))
                {
                    Car currentCar = cars.Where(c => c.Model == currentModel).First();
                    currentCar.Drive(currentDistance);
                }

            }
        }

        private static void AddCars(int carsCount, List<Car> cars)
        {
            for (int i = 0; i < carsCount; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car car = new Car(info[0],
                    double.Parse(info[1]),
                    double.Parse(info[2]));

                cars.Add(car);
            }
        }
    }
}
