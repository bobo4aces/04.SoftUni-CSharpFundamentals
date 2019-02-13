namespace FestivalManager.Entities.Sets
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Long : Set
    {
        public Long(string name)
            : base(name, new TimeSpan(0, 60, 0))
        {
        }
    }
}
