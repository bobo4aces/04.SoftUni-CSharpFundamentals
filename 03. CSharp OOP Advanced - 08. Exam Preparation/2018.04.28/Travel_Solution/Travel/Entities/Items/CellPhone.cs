using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Items
{
    public class CellPhone : Item
    {
        private const int CellPhoneValue = 700;

        public CellPhone() 
            : base(CellPhoneValue)
        {
        }
    }
}
