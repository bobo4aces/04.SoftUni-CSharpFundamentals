using _07._Inferno_Infinity.Contracts;
using _07._Inferno_Infinity.Enums;
using System;
using System.Linq;
using System.Reflection;

namespace _07._Inferno_Infinity.Core.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponRearity, string weaponType, string weaponName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().First(t=>t.Name == weaponType);
            IWeapon instance = (IWeapon)Activator.CreateInstance(type, new object[] { weaponName, Enum.Parse<Rearity>(weaponRearity) });
            return instance;
        }
    }
}
