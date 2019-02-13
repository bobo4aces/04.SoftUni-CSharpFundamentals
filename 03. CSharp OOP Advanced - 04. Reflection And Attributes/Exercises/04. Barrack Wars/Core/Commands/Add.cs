using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public class Add : Command
    {

        private IUnit unit;
        public Add(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            this.unit = base.UnitFactory.CreateUnit(base.Data[1]);
            this.Repository.AddUnit(this.unit);
            string output = base.Data[1] + " added!";
            return output;
        }
    }
}
