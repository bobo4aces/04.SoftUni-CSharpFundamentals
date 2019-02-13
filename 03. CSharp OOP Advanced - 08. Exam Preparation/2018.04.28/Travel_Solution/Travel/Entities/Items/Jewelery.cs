using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Items
{
    public class Jewelery : Item
    {
        private const int JeweleryValue = 300;

        public Jewelery() 
            : base(JeweleryValue)
        {
        }
    }
}
