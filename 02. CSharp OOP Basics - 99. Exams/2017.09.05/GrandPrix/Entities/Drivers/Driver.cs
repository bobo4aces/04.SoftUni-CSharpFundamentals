using GrandPrix.Entities.Cars;

namespace GrandPrix.Entities.Drivers
{
    public abstract class Driver
    {
        private double speed;

        public string Name { get; private set; }
        public double TotalTime { get; set; }
        public Car Car { get; private set; }
        public virtual double FuelConsumptionPerKm { get; set; }
        public string CrashReason { get; set; }

        protected Driver(string name, Car car)
        {
            Name = name;
            Car = car;
        }
        

        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = CalculateSpeed();
            }
        }

        public double CalculateSpeed()
        {
            return (Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;
        }

    }
}
