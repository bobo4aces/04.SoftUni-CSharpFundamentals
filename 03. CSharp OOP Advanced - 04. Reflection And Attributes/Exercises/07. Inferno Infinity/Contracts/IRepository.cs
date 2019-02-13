using System.Collections.Generic;

namespace _07._Inferno_Infinity.Contracts
{
    public interface IRepository
    {
        void AddWeapon(IWeapon weapon);
        void RemoveWeapon(IWeapon weapon);
        List<IWeapon> GetWeapons();
    }
}
