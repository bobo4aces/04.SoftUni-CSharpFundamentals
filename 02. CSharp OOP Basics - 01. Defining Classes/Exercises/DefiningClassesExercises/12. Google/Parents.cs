using System;

namespace Google
{
    public class Parents
    {
        public string Name { get; set; }
        public string Birthday { get; set; }

        public Parents(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return $"{Name} {Birthday}";
        }

    }
}
