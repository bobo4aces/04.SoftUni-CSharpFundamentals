using _07._Inferno_Infinity.Contracts;
using _07._Inferno_Infinity.Core;
using _07._Inferno_Infinity.Core.Factories;
using _07._Inferno_Infinity.Core.IO;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _07._Inferno_Infinity
{
    public class StartUp
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            IRunnable engine = new Engine(commandInterpreter, writer, reader);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IWeaponFactory, WeaponFactory>();
            services.AddTransient<IGemFactory, GemFactory>();
            services.AddTransient<IWriter, ConsoleWriter>();
            services.AddSingleton<IRepository, WeaponRepository>()
            IServiceProvider provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
