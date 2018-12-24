using System;


namespace CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine, string weight = "n/a", string color = "n/a")
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Model}:" +
                $"\n  {Engine.Model}:" +
                $"\n    Power: {Engine.Power}" +
                $"\n    Displacement: {Engine.Displacement}" +
                $"\n    Efficiency: {Engine.Efficiency}" +
                $"\n  Weight: {Weight}" +
                $"\n  Color: {Color}";
        }
    }
}
