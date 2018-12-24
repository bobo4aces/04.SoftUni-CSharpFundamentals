using GrandPrix.Entities.Cars;

namespace GrandPrix.Entities.Drivers
{
    public class EnduranceDriver : Driver
    {
        private const double enduranceDriverfuelConsumptionPerKm = 1.5;

        public EnduranceDriver(string name, Car car) 
            : base(name, car)
        {
            FuelConsumptionPerKm = enduranceDriverfuelConsumptionPerKm;
        }
    }
}
