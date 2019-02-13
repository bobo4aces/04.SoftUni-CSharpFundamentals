using _07._Inferno_Infinity.Enums;
using System.Collections.Generic;

namespace _07._Inferno_Infinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }
        int MinDamage { get; }
        int MaxDamage { get; }
        int Sockets { get; }
        Rearity Rearity { get; }
        IGem[] Gems { get; }
        void AddGem(int index, IGem gem);
        void RemoveGem(int index);
    }
}
