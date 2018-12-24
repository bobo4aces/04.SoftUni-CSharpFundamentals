using System;
using System.Linq;

namespace Vehicles
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int commandsCount = int.Parse(Console.ReadLine());

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
                string action = command[0]?.ToLower();
                string vehicleType = command[1]?.ToLower();
                double quantity = double.Parse(command[2]);

                switch (action)
                {
                    case "drive":
                        if (vehicleType == "car")
                        {
                            car.Drive(quantity);
                        }
                        else if (vehicleType == "truck")
                        {
                            truck.Drive(quantity);
                        }
                        break;
                    case "refuel":
                        if (vehicleType == "car")
                        {
                            car.Refuel(quantity);
                        }
                        else if (vehicleType == "truck")
                        {
                            truck.Refuel(quantity);
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
