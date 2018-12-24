using System;

namespace Google
{
    public class Children
    {
        public string Name { get; set; }
        public string Birthday { get; set; }

        public Children(string name, string birthday)
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
