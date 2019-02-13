using _07._Inferno_Infinity.Enums;

namespace _07._Inferno_Infinity.Entities.Weapons
{
    public class Knife : Weapon
    {
        private const int defaultMinDamage = 3;
        private const int defaultMaxDamage = 4;
        private const int defaultSockets = 2;
        public Knife(string name, Rearity rearity)
            : base(name, defaultMinDamage, defaultMaxDamage, defaultSockets, rearity)
        {
        }
    }
}
