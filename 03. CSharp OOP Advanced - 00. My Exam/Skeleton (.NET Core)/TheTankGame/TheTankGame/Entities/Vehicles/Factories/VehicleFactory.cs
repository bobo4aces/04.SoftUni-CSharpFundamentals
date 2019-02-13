using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == vehicleType);
            Type assemblerType = typeof(VehicleAssembler);
            VehicleAssembler vehicleAssembler = (VehicleAssembler)Activator.CreateInstance(assemblerType);
            IVehicle vehicle = (IVehicle)Activator.CreateInstance(type, new object[] {
                model,
                weight,
                price,
                attack,
                defense,
                hitPoints,
                vehicleAssembler  });
            return vehicle;
        }
    }
}
