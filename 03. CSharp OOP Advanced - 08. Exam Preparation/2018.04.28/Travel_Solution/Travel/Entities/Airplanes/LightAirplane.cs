using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Airplanes
{
    public class LightAirplane : Airplane
    {
        private const int LightAirplaneSeats = 5;
        private const int LightAirplaneBaggageCompartments = 8;

        public LightAirplane() 
            : base(LightAirplaneSeats, LightAirplaneBaggageCompartments)
        {
        }
    }
}
