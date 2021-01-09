using System;
using System.Linq;
using System.Collections.Generic;

namespace PredicateParty
{
    public class StartUp
    {
        public static void Main()
        {
            var guests = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                var commandArgs = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                if (command.StartsWith("Double"))
                {
                    DoubleStr(commandArgs[1], commandArgs[2], guests);
                }
                else if (command.StartsWith("Remove"))
                {
                    RemoveStr(commandArgs[1], commandArgs[2], guests);
                }
            }
            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " " + "are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void RemoveStr(string v1, string v2, List<string> guests)
        {
            if (v1 == "Length")
            {
                for (int i = 0; i < guests.Count; i++)
                {
                    if (guests[i].Length == int.Parse(v2))
                    {
                        guests.Remove(guests[i]);
                        i--;
                    }
                }
            }
            else if (v1 == "StartsWith")
            {
                for (int i = 0; i < guests.Count; i++)
                {
                    if (guests[i].StartsWith(v2))
                    {
                        guests.Remove(guests[i]);
                        i--;
                    }
                }
            }
            else if (v1 == "EndsWith")
            {
                for (int i = 0; i < guests.Count; i++)
                {
                    if (guests[i].EndsWith(v2))
                    {
                        guests.Remove(guests[i]);
                        i--;
                    }
                }
            }
        }


        private static void DoubleStr(string v1, string v2, List<string> guests)
        {
            if (v1 == "Length")
            {
                for (int i = 0; i < guests.Count; i++)
                {
                    if (guests[i].Length == int.Parse(v2))
                    {
                        guests.Insert(i, guests[i]);
                        i++;
                    }
                }
            }
            else if (v1 == "StartsWith")
            {
                for (int i = 0; i < guests.Count; i++)
                {
                    if (guests[i].StartsWith(v2))
                    {
                        guests.Insert(i, guests[i]);
                        i++;
                    }
                }
            }
            else if (v1 == "EndsWith")
            {
                for (int i = 0; i < guests.Count; i++)
                {
                    if (guests[i].EndsWith(v2))
                    {
                        guests.Insert(i, guests[i]);
                        i++;
                    }
                }
            }
        }
    }
}