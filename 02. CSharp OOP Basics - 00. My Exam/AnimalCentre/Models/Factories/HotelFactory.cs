using AnimalCentre.Models.Hotels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Factories
{
    public class HotelFactory
    {
        public Hotel CreateHotel()
        {
            return new Hotel();
        }
    }
}
