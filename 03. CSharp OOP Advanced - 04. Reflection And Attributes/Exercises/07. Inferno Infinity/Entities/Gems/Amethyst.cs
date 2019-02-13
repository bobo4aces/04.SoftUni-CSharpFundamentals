using _07._Inferno_Infinity.Enums;

namespace _07._Inferno_Infinity.Entities.Gems
{
    public class Amethyst : Gem
    {
        private const int defaultStrength = 2;
        private const int defaultAgility = 8;
        private const int defaultVitality = 4;
        public Amethyst(Clarity clarity)
            : base(defaultStrength, defaultAgility, defaultVitality, clarity)
        {
        }
    }
}
