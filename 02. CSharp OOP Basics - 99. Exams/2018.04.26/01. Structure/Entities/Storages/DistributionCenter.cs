using System;
using System.Collections.Generic;
using StorageMaster.Vehicles;

namespace StorageMaster.Storages
{
    public class DistributionCenter : Storage
    {
        private const int defaultCapacity = 2;
        private const int defaultGarageSlots = 5;
        private static Vehicle[] defaultVehicles = new Vehicle[]
        {
            new Van(),
            new Van(),
            new Van()
        };
        public DistributionCenter(string name)
            : base(name, defaultCapacity, defaultGarageSlots, defaultVehicles)
        {
        }
    }
}
