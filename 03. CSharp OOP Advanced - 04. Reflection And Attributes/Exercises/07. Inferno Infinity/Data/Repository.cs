using _07._Inferno_Infinity.Contracts;
using System.Collections.Generic;

namespace _07._Inferno_Infinity.Data
{
    public class Repository : IRepository
    {
        private List<IWeapon> weapons;

        public Repository()
        {
            this.weapons = new List<IWeapon>();
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public void RemoveWeapon(IWeapon weapon)
        {
            weapons.Remove(weapon);
        }

        public List<IWeapon> GetWeapons()
        {
            return this.weapons;
        }
    }
}
