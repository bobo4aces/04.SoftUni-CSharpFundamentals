using _07._Inferno_Infinity.Enums;

namespace _07._Inferno_Infinity.Entities.Gems
{
    public class Ruby : Gem
    {
        private const int defaultStrength = 7;
        private const int defaultAgility = 2;
        private const int defaultVitality = 5;
        public Ruby(Clarity clarity)
            : base(defaultStrength, defaultAgility, defaultVitality, clarity)
        {
        }
    }
}
