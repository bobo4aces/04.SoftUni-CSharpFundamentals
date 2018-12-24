using System;
using System.Collections.Generic;

namespace Google
{
    public class Person
    {
        public string Name { get; set; }
        public Company Company { get; set; }
        public Car Car { get; set; }
        public List<Parents> Parents { get; set; }
        public List<Children> Children { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Person(string name)
        {
            Name = name;
            Parents = new List<Parents>();
            Children = new List<Children>();
            Pokemons = new List<Pokemon>();
        }

        public override string ToString()
        {
            string output = $"{Name}\n";
            output += $"Company:\n";
            if (Company?.ToString() != null)
            {
                output += $"{Company?.ToString()}\n";
            }
            output += $"Car:\n";
            if (Car?.ToString() != null)
            {
                output += $"{Car?.ToString()}\n";
            }
            output += $"Pokemon:\n";
            Pokemons.ForEach(p => output += p.ToString() + "\n");
            output += $"Parents:\n";
            Parents.ForEach(p => output += p.ToString() + "\n");
            output += $"Children:\n";
            Children.ForEach(c => output += c.ToString() + "\n");
            return output.Trim();
        }
    }
}
