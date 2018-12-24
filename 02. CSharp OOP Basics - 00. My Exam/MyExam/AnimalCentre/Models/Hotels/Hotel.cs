using AnimalCentre.Models.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Hotels
{
    public abstract class Hotel
    {
        private readonly int Capacity = 10;
        private Dictionary<string, Animal> Animals;
    }
}
