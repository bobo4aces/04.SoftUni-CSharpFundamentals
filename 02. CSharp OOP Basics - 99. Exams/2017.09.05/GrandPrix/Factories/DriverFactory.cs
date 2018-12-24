using GrandPrix.Entities.Cars;
using GrandPrix.Entities.Drivers;

namespace GrandPrix.Factories
{
    public class DriverFactory
    {
        public Driver CreateDriver(string type, string name, Car car)
        {
            type = type.ToLower();

            switch (type)
            {
                case "aggressive":
                    return new AggressiveDriver(name, car);
                case "endurance":
                    return new EnduranceDriver(name, car);
                default:
                    return null;
            }
        }
    }
}
