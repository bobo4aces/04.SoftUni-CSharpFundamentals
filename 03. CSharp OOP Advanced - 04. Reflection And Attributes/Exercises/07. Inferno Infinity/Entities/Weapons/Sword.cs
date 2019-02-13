using _07._Inferno_Infinity.Enums;

namespace _07._Inferno_Infinity.Entities.Weapons
{
    public class Sword : Weapon
    {
        private const int defaultMinDamage = 4;
        private const int defaultMaxDamage = 6;
        private const int defaultSockets = 3;
        public Sword(string name, Rearity rearity)
            : base(name, defaultMinDamage, defaultMaxDamage, defaultSockets, rearity)
        {
        }
    }
}
