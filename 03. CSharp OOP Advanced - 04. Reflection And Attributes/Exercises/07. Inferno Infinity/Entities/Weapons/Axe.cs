using _07._Inferno_Infinity.Enums;

namespace _07._Inferno_Infinity.Entities.Weapons
{
    public class Axe : Weapon
    {
        private const int defaultMinDamage = 5;
        private const int defaultMaxDamage = 10;
        private const int defaultSockets = 4;
        public Axe(string name, Rearity rearity) 
            : base(name, defaultMinDamage, defaultMaxDamage, defaultSockets, rearity)
        {
        }
    }
}
