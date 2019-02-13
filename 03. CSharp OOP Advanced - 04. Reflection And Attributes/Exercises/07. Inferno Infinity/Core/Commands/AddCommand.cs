using _07._Inferno_Infinity.Contracts;
using _07._Inferno_Infinity.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Inferno_Infinity.Core.Commands
{
    public class AddCommand : Command
    {
        public AddCommand(string[] data, IRepository repository, IGemFactory gemFactory) 
            : base(data)
        {
            this.Repository = repository;
            this.GemFactory = gemFactory;
        }
        [Inject]
        public IRepository Repository { get; }

        [Inject]
        public IGemFactory GemFactory { get; }
        public override void Execute()
        {
            List<IWeapon> weapons = this.Repository.GetWeapons();
            IWeapon weapon = weapons.FirstOrDefault(w => w.Name == base.Data[1]);
            if (weapon != null)
            {
                string[] gemInfo = base.Data[3]
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
                IGem gem = this.GemFactory.CreateGem(gemInfo[0], gemInfo[1]);
                weapon.AddGem(int.Parse(base.Data[2]),gem);
            }
        }
    }
}
