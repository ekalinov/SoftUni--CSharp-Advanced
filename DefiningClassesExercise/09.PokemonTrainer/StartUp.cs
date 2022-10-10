using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Tournament")
                {
                    break;
                }

                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"

                string[] inputArg = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trName = inputArg[0];
                string pkName = inputArg[1];
                string pkElement = inputArg[2];
                int pkHealth = int.Parse(inputArg[3]);

                if (!trainers.ContainsKey(trName))
                {
                    trainers.Add(trName, new Trainer() { Name = trName });
                    trainers[trName].Pokemons = new List<Pokemon>();

                }


                Pokemon pokemon = new Pokemon
                {
                    Element = pkElement,
                    Name = pkName,
                    Health = pkHealth
                };

                trainers[trName].Pokemons.Add(pokemon);
                trainers[trName].Badges = 0;

            }


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }



                foreach (var trainer in trainers)
                {
                    bool hasPokemon = false;

                    foreach (var pokemon in trainer.Value.Pokemons)
                    {
                        if (pokemon.Element == input)
                        {
                            hasPokemon = true;
                        }
                    }

                    if (hasPokemon)
                    {
                        trainers[trainer.Key].Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Value.Pokemons.Count; i++)
                        {
                            Pokemon pokemon= trainer.Value.Pokemons[i];
                            pokemon.Health -= 10;
                            if (pokemon.Health <= 0)
                            {
                                trainer.Value.Pokemons.Remove(pokemon);
                            }
                        }

                    }


                }


            }


            foreach (var trainer in trainers.Values.OrderByDescending(x=>x.Badges))
            {
                Console.Write($"{trainer.Name} ");
                Console.Write($"{trainer.Badges} ");
                Console.WriteLine(trainer.Pokemons.Count);
            }


        }
    }
}
