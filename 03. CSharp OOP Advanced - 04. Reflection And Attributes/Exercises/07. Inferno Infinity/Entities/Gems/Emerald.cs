using _07._Inferno_Infinity.Enums;

namespace _07._Inferno_Infinity.Entities.Gems
{
    public class Emerald : Gem
    {
        private const int defaultStrength = 1;
        private const int defaultAgility = 4;
        private const int defaultVitality = 9;
        public Emerald(Clarity clarity)
            : base(defaultStrength, defaultAgility, defaultVitality, clarity)
        {
        }
    }
}
