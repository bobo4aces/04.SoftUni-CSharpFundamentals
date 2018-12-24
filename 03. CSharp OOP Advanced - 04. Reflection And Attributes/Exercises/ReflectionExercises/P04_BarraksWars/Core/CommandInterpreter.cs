using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core;

namespace P04_BarraksWars.Core
{
    public class CommandInterpreter : Command
    {

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory, string[] data) 
            : base(repository, unitFactory, data)
        {
        }

        public override string Execute()
        {
            Type type = typeof(Engine);
            ConstructorInfo constructor = type.GetConstructor(new Type[] { type });
            constructor.Invoke(type, new object[] { this.Repository, this.UnitFactory });
            return "Pesho";
        }
    }
}
