using System;

namespace Ferrari
{
    public class Ferrari : IFerrari
    {
        public string Model { get; set; } = "488-Spider";

        public string Driver { get; set; }

        public Ferrari(string driver)
        {
            Driver = driver;
        }

        public string PushGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.UseBrakes()}/{this.PushGasPedal()}/{this.Driver}";
        }
    }
}
