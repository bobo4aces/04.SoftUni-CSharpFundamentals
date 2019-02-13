using _07._Inferno_Infinity.Contracts;
using _07._Inferno_Infinity.Core.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace _07._Inferno_Infinity.Core.Commands
{
    public class RemoveCommand : Command
    {
        public RemoveCommand(string[] data, IRepository repository) 
            : base(data)
        {
        }

        [Inject]
        public IRepository Repository { get; }

        public override void Execute()
        {
            List<IWeapon> weapons = this.Repository.GetWeapons();
            IWeapon weapon = weapons.FirstOrDefault(w => w.Name == base.Data[1]);
            if (weapon != null)
            {
                int socketIndex = int.Parse(base.Data[2]);
                weapon.RemoveGem(socketIndex);
            }
        }
    }
}
