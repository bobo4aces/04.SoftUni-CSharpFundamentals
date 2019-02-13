using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Entities.Providers
{
    public class PressureProvider : Provider
    {
        public PressureProvider(int id, double energyOutput) 
            : base(id, energyOutput)
        {
            this.Durability -= 300;
            this.EnergyOutput *= 2;
        }
    }
}
