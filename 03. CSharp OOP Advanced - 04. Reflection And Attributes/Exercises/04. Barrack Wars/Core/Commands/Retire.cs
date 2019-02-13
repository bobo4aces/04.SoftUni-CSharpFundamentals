using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.Data;

namespace P03_BarraksWars.Core.Commands
{
    public class Retire : Command
    {
        public Retire(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unit = this.Data[1];
            base.Repository.RemoveUnit(unit);
            return $"{unit} retired!";
        }
    }
}
