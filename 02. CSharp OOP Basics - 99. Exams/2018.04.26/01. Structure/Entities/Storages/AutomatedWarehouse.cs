using StorageMaster.Vehicles;
using System.Collections;
using System.Collections.Generic;

namespace StorageMaster.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int defaultCapacity = 1;
        private const int defaultGarageSlots = 2;
        private static Vehicle[] defaultVehicles = new Vehicle[]
        {
            new Truck()
        };

        public AutomatedWarehouse(string name)
            : base(name, defaultCapacity, defaultGarageSlots, defaultVehicles)
        {
        }
    }
}
