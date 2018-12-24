using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main()
        {
            string[] command = ReadCommand();

            List<Trainer> trainers = new List<Trainer>();
            List<Pokemon> pokemons = new List<Pokemon>();

            while (command[0]?.ToLower() != "tournament")
            {
                if (command.Length == 4)
                {
                    string currentTrainerName = command[0];

                    //Checks if trainers' list contains current trainer
                    if (!trainers.Any(t=>t.Name == currentTrainerName))
                    {
                        Trainer trainer = new Trainer(currentTrainerName);
                        trainers.Add(trainer);
                    }

                    Pokemon pokemon = new Pokemon(command[1], command[2], int.Parse(command[3]));

                    //Adding pokemons to the current trainer
                    trainers
                        .Where(t => t.Name == currentTrainerName)
                        .First()
                        .Pokemons
                        .Add(pokemon);
                }

                command = ReadCommand();
            }

            string element = Console.ReadLine().ToLower();

            while (element != "end")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p=>p.Element.ToLower() == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                    }
                    trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                }

                element = Console.ReadLine().ToLower();
            }

            foreach (var trainer in trainers.OrderByDescending(t=>t.Badges))
            {
                Console.WriteLine(trainer.ToString());
            }
        }

        private static string[] ReadCommand()
        {
            return Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
        }
    }
}
