using System;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        string[] carInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

        string[] truckInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

        string[] busInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

        int countOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfCommands; i++)
        {
            string[] commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            string command = commandArgs[0];
            string typeOfVehicle = commandArgs[1];
            double givenParam = double.Parse(commandArgs[2]);

            Vehicle vehicleToOperate;
            if (typeOfVehicle == "Car")
                vehicleToOperate = car;
            else if (typeOfVehicle == "Truck")
                vehicleToOperate = truck;
            else
                vehicleToOperate = bus;

            try
            {
                switch (command)
                {
                    case "Drive":
                        vehicleToOperate.Drive(givenParam);
                        Console.WriteLine($"{vehicleToOperate.GetType().Name} travelled {givenParam} km");
                        break;
                    case "DriveEmpty":
                        ((Bus)vehicleToOperate).DriveEmpty(givenParam);
                        Console.WriteLine($"{vehicleToOperate.GetType().Name} travelled {givenParam} km");
                        break;
                    case "Refuel":
                        vehicleToOperate.Refuel(givenParam);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }
}
