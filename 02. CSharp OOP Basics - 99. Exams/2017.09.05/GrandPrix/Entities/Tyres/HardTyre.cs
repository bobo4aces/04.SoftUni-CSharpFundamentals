namespace GrandPrix.Entities.Tyres
{
    public class HardTyre : Tyre
    {
        private const string hardTyreName = "Hard";

        private string name;

        public HardTyre(string name, double hardness) 
            : base(name, hardness)
        {
            Name = name;
        }

        public new string Name
        {
            get { return name; }
            set { name = hardTyreName; }
        }

    }
}
