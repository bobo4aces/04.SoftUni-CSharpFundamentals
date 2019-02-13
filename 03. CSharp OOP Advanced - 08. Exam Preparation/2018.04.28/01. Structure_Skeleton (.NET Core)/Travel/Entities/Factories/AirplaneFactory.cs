namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System;
    using System.Reflection;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            Type airplaneType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            IAirplane instance = (IAirplane)Activator.CreateInstance(airplaneType);
            return instance;
		}
	}
}