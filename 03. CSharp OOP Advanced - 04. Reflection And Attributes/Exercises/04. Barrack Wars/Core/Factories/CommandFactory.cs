using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P03_BarraksWars.Core.Factories
{
    public class CommandFactory
    {

        public IExecutable CreateCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            string firstLetter = data[0][0].ToString().ToUpper();
            string type = firstLetter + string.Join("", data[0].Skip(1));

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            if (model == null)
            {
                throw new ArgumentException("Invalid Unit Type!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{type} is not a Unit Type!");
            }

            return (IExecutable)Activator.CreateInstance(model, new object[] { data, repository, unitFactory });
        }
    }
}
