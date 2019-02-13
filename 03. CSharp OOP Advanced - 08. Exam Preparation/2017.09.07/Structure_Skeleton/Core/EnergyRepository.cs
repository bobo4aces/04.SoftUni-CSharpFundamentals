using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Core
{
    public class EnergyRepository : IEnergyRepository
    {
        public double EnergyStored { get; private set; }

        public void StoreEnergy(double energy)
        {
            throw new NotImplementedException();
        }

        public bool TakeEnergy(double energyNeeded)
        {
            throw new NotImplementedException();
        }
    }
}
