using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SoftUniKaraoke
{
    public class StartUp
    {
        public static void Main()
        {
            List<Performer> performers = new List<Performer>();
            List<string> participants = Console.ReadLine()
                .Split(',').ToList();
            for (int i = 0; i < participants.Count; i++)
            {
                participants[i] = participants[i].Trim();
            }
            List<string> songs = Console.ReadLine()
                .Split(',').ToList();
            for (int i = 0; i < songs.Count; i++)
            {
                songs[i] = songs[i].Trim();
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "dawn")
                {
                    break;
                }
                var awardsAndPerformers = input
                    .Split(',')
                    .ToList();
                string participant = awardsAndPerformers[0].Trim();
                string song = awardsAndPerformers[1].Trim();
                string award = awardsAndPerformers[2].Trim();
                if (participants.Contains(participant) && songs.Contains(song))
                {
                    Performer performer = new Performer();
                    performer.Name = participant;
                    if (performers.Any(x => x.Name == participant))
                    {
                        var currentPerformer = performers.First(x => x.Name == participant);
                        if (!currentPerformer.Awards.Contains(award))
                        {
                            currentPerformer.Awards.Add(award);
                        }
                    }
                    else
                    {
                        performers.Add(performer);
                        performer.Awards.Add(award);
                    }
                }
            }
            PrintResult(performers);
        }

        private static void PrintResult(List<Performer> performers)
        {
            if (performers.Count > 0)
            {
                foreach (Performer performer in performers.OrderByDescending(x => x.Awards.Count).ThenBy(x => x.Name))
                {
                    Console.WriteLine($"{performer.Name}: {performer.Awards.Count} awards");
                    foreach (var award in performer.Awards.OrderBy(x => x))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
    class Performer
    {
        public string Name { get; set; }
        public List<string> Awards { get; set; }
        public Performer()
        {
            Awards = new List<string>();
        }
    }
}
