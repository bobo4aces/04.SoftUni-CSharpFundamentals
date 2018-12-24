using System;

namespace GrandPrix.Entities.Tyres
{
    public abstract class Tyre
    {
        private const double startingDegradation = 100;
        private const double minDegradation = 0;

        private double degradation;

        protected string Name { get; private set; }
        public double Hardness { get; private set; }

        protected Tyre(string name, double hardness)
        {
            Name = name;
            Hardness = hardness;
            Degradation = startingDegradation;
        }

        public virtual double Degradation
        {
            get
            {
                return degradation;
            }
            set
            {
                if (value < minDegradation)
                {
                    throw new InvalidOperationException("Blown Tyre");
                }
                degradation = value;
            }
        }

        public virtual void ReduceDegradation()
        {
            Degradation -= Hardness;
        }
    }
}
