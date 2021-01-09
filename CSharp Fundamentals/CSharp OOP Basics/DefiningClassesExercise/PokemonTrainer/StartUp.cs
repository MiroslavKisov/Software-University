using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var trainers = new Dictionary<string, Trainer>();
        var trainersName = new List<string>();
        while (true)
        {
            string input = Console.ReadLine();
            var trainerArgs = input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (input == "Tournament")
            {
                break;
            }

            string trainerName = trainerArgs[0];
            string pokemonName = trainerArgs[1];
            string pokemonElement = trainerArgs[2];
            int pokemonHealth = int.Parse(trainerArgs[3]);
            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            Trainer trainer = new Trainer(trainerName);
            trainersName.Add(trainerName);
            if (!trainers.ContainsKey(trainer.Name))
            {
                trainers.Add(trainerName, trainer);
                trainers[trainerName].Pokemons.Add(pokemon);
            }
            else
            {
                trainers[trainerName].Pokemons.Add(pokemon);
            }
        }
        trainersName = trainersName.Distinct().ToList();
        while (true)
        {
            var removalList = new List<string>();
            string element = Console.ReadLine();
            if (element == "End")
            {
                break;
            }
            for (int i = 0; i < trainersName.Count; i++)
            {
                if (trainers[trainersName[i]].Pokemons.Exists(x => x.Element == element))
                {
                    trainers[trainersName[i]].NumberOfBadges++;
                }
                else
                {
                    removalList.Add(trainersName[i]);
                }
            }
            for (int i = 0; i < removalList.Count; i++)
            {
                trainers[removalList[i]].Pokemons.ForEach(x => x.Health -= 10);
                trainers[removalList[i]].Pokemons.RemoveAll(x => x.Health <= 0);
            }
            removalList.Clear();
        }
        foreach (var trainer in trainers.OrderByDescending(x => x.Value.NumberOfBadges))
        {
            Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBadges} {trainer.Value.Pokemons.Count}");
        }
    }
}
