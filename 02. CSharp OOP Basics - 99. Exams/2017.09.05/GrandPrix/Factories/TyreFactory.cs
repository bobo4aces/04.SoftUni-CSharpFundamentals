using GrandPrix.Entities.Tyres;

namespace GrandPrix.Factories
{
    public class TyreFactory
    {
        public Tyre CreateTyre (string name, double hardness)
        {
            name = name.ToLower();

            switch (name)
            {
                case "hard":
                    return new HardTyre(name, hardness);
                default:
                    return null;
            }
        }
        public Tyre CreateTyre(string name, double hardness, double grip)
        {
            name = name.ToLower();

            switch (name)
            {
                case "ultrasoft":
                    return new UltrasoftTyre(name, hardness, grip);
                default:
                    return null;
            }
        }
    }
}
