using System;

namespace GrandPrix.Entities.Tyres
{
    public class UltrasoftTyre : Tyre
    {
        private const string ultrasoftTyreName = "Ultrasoft";
        private const double minDegradation = 30;

        public double Grip { get; private set; }
        private double degradation;

        public UltrasoftTyre(string name, double hardness, double grip) 
            : base(name, hardness)
        {
            name = ultrasoftTyreName;
            Grip = grip;
        }

        public new double Degradation
        {
            get
            {
                return degradation;
            }
            private set
            {
                if (value < minDegradation)
                {
                    throw new InvalidOperationException("Tyre blows up!");
                }
                degradation = value;
            }
        }

        public override void ReduceDegradation()
        {
            Degradation -= Hardness + Grip;
        }
    }
}
