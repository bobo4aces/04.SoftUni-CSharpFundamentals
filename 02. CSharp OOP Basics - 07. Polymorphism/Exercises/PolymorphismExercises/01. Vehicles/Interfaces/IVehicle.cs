using System;

namespace Vehicles
{
    public interface IVehicle
    {
        void Drive(double distance);
        void Refuel(double fuelAmount);
    }
}
