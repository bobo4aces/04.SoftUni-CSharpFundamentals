using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Items
{
    public class Laptop : Item
    {
        private const int LaptopValue = 3000;

        public Laptop()
            : base(LaptopValue)
        {
        }
    }
}
