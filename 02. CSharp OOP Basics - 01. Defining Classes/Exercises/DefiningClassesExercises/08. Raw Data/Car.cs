using System;
using System.Collections.Generic;

namespace RawData
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public List<Tire> Tires { get; set; }

        public Car(string[] info)
        {
            Model = info[0];
            Engine = new Engine(int.Parse(info[1]),int.Parse(info[2]));
            Cargo = new Cargo(int.Parse(info[3]), info[4]);
            Tires = new List<Tire>();
            for (int i = 0; i < 4; i++)
            {
                Tire tyre = new Tire(double.Parse(info[5 + i*2]), int.Parse(info[6 + i*2]));
                Tires.Add(tyre);
            }
        }
    }
}
