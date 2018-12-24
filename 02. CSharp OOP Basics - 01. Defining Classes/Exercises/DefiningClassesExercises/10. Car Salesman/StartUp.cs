using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main()
        {
            int enginesCount = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            AddEngines(enginesCount, engines);

            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            AddCars(engines, carsCount, cars);

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        private static void AddCars(List<Engine> engines, int carsCount, List<Car> cars)
        {
            for (int i = 0; i < carsCount; i++)
            {
                string[] info = ReadInput();

                Engine currentEngine = engines.Where(e => e.Model == info[1]).FirstOrDefault();
                if (info.Length == 2)
                {
                    Car car = new Car(info[0], currentEngine);
                    cars.Add(car);
                }
                else if (info.Length == 3)
                {
                    int zero = 0;
                    if (int.TryParse(info[2], out zero))
                    {
                        Car car = new Car(info[0], currentEngine, info[2]);
                        cars.Add(car);
                    }
                    else
                    {
                        Car car = new Car(info[0], currentEngine, "n/a", info[2]);
                        cars.Add(car);
                    }
                }
                else
                {
                    Car car = new Car(info[0], currentEngine, info[2], info[3]);
                    cars.Add(car);
                }
            }
        }

        private static void AddEngines(int enginesCount, List<Engine> engines)
        {
            for (int i = 0; i < enginesCount; i++)
            {
                string[] info = ReadInput();

                if (info.Length == 2)
                {
                    Engine engine = new Engine(info[0], int.Parse(info[1]));
                    engines.Add(engine);
                }
                else if (info.Length == 3)
                {
                    int zero = 0;
                    if (int.TryParse(info[2], out zero))
                    {
                        Engine engine = new Engine(info[0], int.Parse(info[1]), info[2]);
                        engines.Add(engine);
                    }
                    else
                    {
                        Engine engine = new Engine(info[0], int.Parse(info[1]), "n/a", info[2]);
                        engines.Add(engine);
                    }
                }
                else
                {
                    Engine engine = new Engine(info[0], int.Parse(info[1]), info[2], info[3]);
                    engines.Add(engine);
                }
            }
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
        }
    }
}
