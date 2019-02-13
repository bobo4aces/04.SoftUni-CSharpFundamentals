using _07._Inferno_Infinity.Contracts;
using _07._Inferno_Infinity.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Inferno_Infinity.Core.Commands
{
    public class PrintCommand : Command
    {
        public PrintCommand(string[] data, IRepository repository, IWriter writer) 
            : base(data)
        {
            this.Repository = repository;
            this.Writer = writer;
        }

        [Inject]
        public IRepository Repository { get; }

        [Inject]
        public IWriter Writer { get; }
        public override void Execute()
        {
            List<IWeapon> weapons = this.Repository.GetWeapons();
            IWeapon weapon = weapons.FirstOrDefault(w => w.Name == base.Data[1]);
            if (weapon != null)
            {
                this.Writer.WriteLine(weapon);
            }
        }
    }
}
