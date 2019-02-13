using _07._Inferno_Infinity.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace _07._Inferno_Infinity.Core.Factories
{
    public class CommandFactory
    {
        public IExecutable CreateCommand(string[] data, IRepository repository, IWeaponFactory weaponFactory, IGemFactory gemFactory)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == data[0] + "Command");
            IExecutable executable = (IExecutable)Activator.CreateInstance(type,new object[] { data, repository, weaponFactory, gemFactory});
            return executable;
        }
    }
}
