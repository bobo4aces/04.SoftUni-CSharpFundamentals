using GrandPrix.Entities.Tyres;
using System;

namespace GrandPrix.Entities.Cars
{
    public class Car
    {
        private const double maxCapacity = 160;

        private double fuelAmount;

        public int Hp { get; private set; }
        public Tyre Tyre { get; set; }

        public Car(int hp, double fuelAmount, Tyre tyre)
        {
            Hp = hp;
            FuelAmount = fuelAmount;
            Tyre = tyre;
        }

        public double FuelAmount
        {
            get
            {
                return fuelAmount;
            }
            set
            {
                if (value > maxCapacity)
                {
                    fuelAmount = maxCapacity;
                }
                else if (value < 0)
                {
                    throw new InvalidOperationException("Out of fuel");
                }
                else
                {
                    fuelAmount = value;
                }  
            }
        }

    }
}
