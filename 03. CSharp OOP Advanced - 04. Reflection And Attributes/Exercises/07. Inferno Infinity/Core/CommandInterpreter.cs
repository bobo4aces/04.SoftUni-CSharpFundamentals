using _07._Inferno_Infinity.Contracts;
using _07._Inferno_Infinity.Core.Attributes;
using _07._Inferno_Infinity.Core.Factories;
using System;
using System.Linq;
using System.Reflection;

namespace _07._Inferno_Infinity.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;
        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data)
        {
            string commandType = data[0];
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(x => x.Name == commandType);
            if (type == null)
            {
                throw new ArgumentException("Invalid type!");
            }
            if (!typeof(IExecutable).IsAssignableFrom(type))
            {
                throw new ArgumentException(type + " is not Weapon type!");
            }
            PropertyInfo[] propertiesToInject = type
                                                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                                .Where(p => p.GetCustomAttributes<InjectAttribute>().Any()).ToArray();
            var injectProps = propertiesToInject
                                        .Select(p => serviceProvider.GetService(p.PropertyType))
                                        .ToArray();
            var joinedParams = new object[] { data }.Concat(injectProps).ToArray();
            IExecutable command = (IExecutable)Activator.CreateInstance(type, joinedParams);
            return command;
        }
    }
}
