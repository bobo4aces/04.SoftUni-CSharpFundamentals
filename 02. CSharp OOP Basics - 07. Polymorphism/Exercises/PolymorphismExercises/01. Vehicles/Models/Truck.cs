using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle, IVehicle
    {
        private const double increasedConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
             : base(fuelQuantity, fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + increasedConsumption;
        }

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * 0.95);
        }
    }
}
