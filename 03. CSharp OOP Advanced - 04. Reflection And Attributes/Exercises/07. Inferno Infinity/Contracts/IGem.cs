using _07._Inferno_Infinity.Enums;

namespace _07._Inferno_Infinity.Contracts
{
    public interface IGem
    {
        int Strength { get; }
        int Agility { get; }
        int Vitality { get; }
        Clarity Clarity { get; }
    }
}
