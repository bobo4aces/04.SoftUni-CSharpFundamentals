using GrandPrix.Entities.Cars;

namespace GrandPrix.Entities.Drivers
{
    public class AggressiveDriver : Driver
    {
        private const double currentfuelConsumptionPerKm = 2.7;
        private const double speedMultiplier = 1.3;

        public AggressiveDriver(string name, Car car) 
            : base(name, car)
        {
            FuelConsumptionPerKm = currentfuelConsumptionPerKm;
            Speed = CalculateSpeed() * speedMultiplier;
        }
    }
}
