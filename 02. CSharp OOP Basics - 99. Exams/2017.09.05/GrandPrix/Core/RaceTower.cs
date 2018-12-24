using GrandPrix.Entities.Cars;
using GrandPrix.Entities.Drivers;
using GrandPrix.Entities.Enums;
using GrandPrix.Entities.Tyres;
using GrandPrix.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrandPrix.Core
{
    public class RaceTower
    {
        private DriverFactory driverFactory;
        private CarFactory carFactory;
        private TyreFactory tyreFactory;
        internal List<Driver> drivers;
        private int totalLapsNumber;
        private int lapsLeft;
        private int currentTrackLength;
        private Enum weather;

        public RaceTower()
        {
            driverFactory = new DriverFactory();
            carFactory = new CarFactory();
            tyreFactory = new TyreFactory();
            drivers = new List<Driver>();
            weather = Weather.Sunny;
            totalLapsNumber = 1;
            lapsLeft = 1;
            currentTrackLength = 1;
        }

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            totalLapsNumber = lapsNumber;
            currentTrackLength = trackLength;
        }
        public void RegisterDriver(List<string> commandArgs)
        {
            //•	RegisterDriver {type} {name} {hp} {fuelAmount} {tyreType} {tyreHardness}
            //•	RegisterDriver {type} {name} {hp} {fuelAmount} Ultrasoft {tyreHardness} { grip}
            if (commandArgs.Count > 8)
            {
                return;
            }
            string type = commandArgs[1];
            string name = commandArgs[2];
            int hp = int.Parse(commandArgs[3]);
            double fuelAmount = double.Parse(commandArgs[4]);
            string tyreType = commandArgs[5];
            double tyreHardness = double.Parse(commandArgs[6]);
            Tyre tyre = null;
            if (commandArgs.Count == 8)
            {
                double grip = double.Parse(commandArgs[7]);
                tyre = tyreFactory.CreateTyre(tyreType, tyreHardness, grip);
            }
            else
            {
                tyre = tyreFactory.CreateTyre(tyreType, tyreHardness);
            }
            if (tyre != null)
            {
                Car car = carFactory.CreateCar(hp, fuelAmount, tyre);
                if (car != null)
                {
                    Driver driver = driverFactory.CreateDriver(type, name, car);
                    drivers.Add(driver);
                }
            }
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            string reasonToBox = commandArgs[1].ToLower();
            string driversName = commandArgs[2];
            Driver driver = drivers.FirstOrDefault(d=>d.Name == driversName);
            driver.TotalTime += 20;
            if (driver != null)
            {
                switch (reasonToBox)
                {
                    case "changetyres":
                        ChangeTyre(commandArgs, driver);
                        break;
                    case "refuel":
                        double fuelAmount = double.Parse(commandArgs[3]);
                        driver.Car.FuelAmount += fuelAmount;
                        break;
                    default:
                        break;
                }
            }
            

            //TODO: Add some logic here …
        }

        private void ChangeTyre(List<string> commandArgs, Driver driver)
        {
            string tyreType = commandArgs[3].ToLower();
            double tyreHardness = double.Parse(commandArgs[4]);
            if (tyreType == "ultrasoft")
            {
                double grip = double.Parse(commandArgs[5]);
                driver.Car.Tyre = tyreFactory.CreateTyre(tyreType, tyreHardness, grip);
            }
            else
            {
                driver.Car.Tyre = tyreFactory.CreateTyre(tyreType, tyreHardness);
            }
        }

        public string CompleteLaps(List<string> commandArgs)
        {
            //•	CompleteLaps {numberOfLaps} 
            int numberOfLaps = int.Parse(commandArgs[1]);
            
            for (int i = 0; i < numberOfLaps; i++)
            {
                if (numberOfLaps < totalLapsNumber)
                {
                    throw new InvalidOperationException($"There is no time! On lap {i}.");
                }
                Race();
                drivers = drivers.OrderByDescending(d => d.TotalTime).ToList();
                for (int j = 0; j < drivers.Count - 1; j++)
                {
                    Driver lastDriver = drivers[j];
                    Driver beforeLastDriver = drivers[j+1];
                    if (lastDriver.CrashReason == null)
                    {
                        continue;
                    }
                    double interval = lastDriver.TotalTime - beforeLastDriver.TotalTime;
                    bool isOvertaken = false;
                    
                    double multiplier = 2;
                    CheckForOverlaping(interval, ref isOvertaken, lastDriver, ref multiplier);
                    if (isOvertaken)
                    {
                        beforeLastDriver.TotalTime -= multiplier;
                        lastDriver.TotalTime += multiplier;
                        return $"{lastDriver.Name} has overtaken {beforeLastDriver.Name} on lap {i}.";
                    }
                }
                lapsLeft--;
            }
            return null;
        }

        private void CheckForOverlaping(double interval, ref bool isOvertaken, Driver lastDriver, ref double multiplier)
        {
            if (lastDriver is AggressiveDriver && lastDriver.Car.Tyre is UltrasoftTyre && interval <= 3)
            {
                if (weather is Weather.Foggy)
                {
                    lastDriver.CrashReason = "Crashed";
                }
                else
                {
                    multiplier *= interval;
                    isOvertaken = true;
                }

            }
            else if (lastDriver is EnduranceDriver && lastDriver.Car.Tyre is HardTyre && interval <= 3)
            {
                if (weather is Weather.Rainy)
                {
                    lastDriver.CrashReason = "Crashed";
                }
                else
                {
                    multiplier *= interval;
                    isOvertaken = true;
                }
            }
            else if (interval <= 2)
            {
                multiplier *= interval;
                isOvertaken = true;
            }
        }

        private void Race()
        {
            foreach (var driver in drivers)
            {
                driver.TotalTime += 60 / (currentTrackLength / driver.Speed);
                driver.Car.FuelAmount -= currentTrackLength * driver.FuelConsumptionPerKm;
                driver.Car.Tyre.ReduceDegradation();
            }
        }

        public string GetLeaderboard()
        {
            //Lap {current lap}/{total laps number}
            //{Position number} {Driver’s Name} {Total time / Failure reason}
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Lap {lapsLeft}/{totalLapsNumber}");
            int count = 0;
            foreach (var driver in drivers.OrderBy(d=>d.TotalTime))
            {
                stringBuilder.AppendLine($"{++count} {driver.Name} {driver.TotalTime}");
            }
            return stringBuilder.ToString().TrimEnd();
            //TODO Failure reason????
        }

        public void ChangeWeather(List<string> commandArgs)
        {
            weather = Enum.Parse<Weather>(commandArgs[1]);
        }

    }
}
