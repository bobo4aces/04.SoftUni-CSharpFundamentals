using _07._Inferno_Infinity.Contracts;
using _07._Inferno_Infinity.Core.Attributes;
using System;
using System.Linq;

namespace _07._Inferno_Infinity.Core.Commands
{
    public class CreateCommand : Command
    {
        public CreateCommand(string[] data, IRepository repository, IWeaponFactory weaponFactory) 
            : base(data)
        {
            this.Repository = repository;
            this.WeaponFactory = weaponFactory;
        }

        [Inject]
        public IRepository Repository { get; }

        [Inject]
        public IWeaponFactory WeaponFactory { get; }
        public override void Execute()
        {
            string[] weaponInfo = base.Data[1]
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
            IWeapon weapon = WeaponFactory.CreateWeapon(weaponInfo[0], weaponInfo[1], base.Data[2]);
            this.Repository.AddWeapon(weapon);
        }
    }
}
