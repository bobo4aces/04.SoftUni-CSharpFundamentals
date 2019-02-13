using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Traffic_Lights
{
    public class TrafficLight
    {
        private TrafficLightColor color;

        public TrafficLight(string color)
        {
            this.color = Enum.Parse<TrafficLightColor>(color);
        }

        public void Update()
        {
            int lastColor = (int)this.color;
            int enumsLength =  Enum.GetNames(typeof(TrafficLightColor)).Length;
            this.color = (TrafficLightColor)(++lastColor % enumsLength);
        }
    }
}
