using _07._Inferno_Infinity.Contracts;
using _07._Inferno_Infinity.Enums;
using System;
using System.Linq;
using System.Reflection;

namespace _07._Inferno_Infinity.Core.Factories
{
    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string gemClarity, string gemType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().First(t => t.Name == gemType);
            IGem instance = (IGem)Activator.CreateInstance(type, new object[] { Enum.Parse<Clarity>(gemClarity) });
            return instance;
        }
    }
}
