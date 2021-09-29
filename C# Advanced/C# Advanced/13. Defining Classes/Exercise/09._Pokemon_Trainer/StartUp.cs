using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Trainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] info = input.Split();
                string trainerName = info[0];
                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainers.Add(trainerName, trainer);
                }

                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainers[trainerName].Pokemons.Add(pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(x=>x.Element == input))
                    {
                        trainer.Value.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Value.Pokemons.ForEach(x=>x.Health -= 10);
                    }

                    trainer.Value.Pokemons.RemoveAll(x => x.Health <= 0);
                }
            }

            trainers
                .OrderByDescending(x => x.Value.NumberOfBadges)
                .ToList()
                .ForEach(x=>Console.WriteLine(x.Value));
        }
    }
}