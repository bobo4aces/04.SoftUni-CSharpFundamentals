using System;
using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name, int badges = 0)
        {
            Name = name;
            Badges = badges;
            Pokemons = new List<Pokemon>();
        }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}
