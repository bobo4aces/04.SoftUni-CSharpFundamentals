using System;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public int TraveledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
        }

        public void Drive(int amountOfKm)
        {
            double distanceCanTravel = FuelAmount / FuelConsumption;
            if (distanceCanTravel >= amountOfKm )
            {
                FuelAmount -= amountOfKm * FuelConsumption;
                TraveledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TraveledDistance}";
        }
    }
}
