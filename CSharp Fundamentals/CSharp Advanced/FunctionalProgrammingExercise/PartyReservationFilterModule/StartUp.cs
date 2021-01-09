using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var indexes = new Dictionary<string, Dictionary<int, string>>();
            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                var commandArgs = command.Split(';').ToArray();

                if (commandArgs[0] == "Add filter")
                {
                    if (commandArgs[1] == "Starts with")
                    {
                        AddFilterStartsWith(names, indexes, commandArgs);
                    }
                    else if (commandArgs[1] == "Ends with")
                    {
                        AddFilterEndsWith(names, indexes, commandArgs);
                    }
                    else if (commandArgs[1] == "Length")
                    {
                        AddFilterLength(names, indexes, commandArgs);
                    }
                    else if (commandArgs[1] == "Contains")
                    {
                        AddFilterContains(names, indexes, commandArgs);
                    }
                }
                else if (commandArgs[0] == "Remove filter")
                {
                    if (commandArgs[1] == "Starts with")
                    {
                        RemoveFilter(names, indexes, commandArgs);
                    }
                    else if (commandArgs[1] == "Ends with")
                    {
                        RemoveFilter(names, indexes, commandArgs);
                    }
                    else if (commandArgs[1] == "Length")
                    {
                        RemoveFilter(names, indexes, commandArgs);
                    }
                    else if (commandArgs[1] == "Contains")
                    {
                        RemoveFilter(names, indexes, commandArgs);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", names.Where(n => n != " ")));
        }

        private static void AddFilterContains(string[] names, Dictionary<string, Dictionary<int, string>> indexes, string[] commandArgs)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Contains(commandArgs[2]))
                {
                    if (!indexes.ContainsKey(commandArgs[2]))
                    {
                        indexes.Add(commandArgs[2], new Dictionary<int, string>());
                    }
                    indexes[commandArgs[2]].Add(i, names[i]);
                    names[i] = " ";
                }
            }
        }

        private static void AddFilterLength(string[] names, Dictionary<string, Dictionary<int, string>> indexes, string[] commandArgs)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Length == int.Parse(commandArgs[2]))
                {
                    if (!indexes.ContainsKey(commandArgs[2]))
                    {
                        indexes.Add(commandArgs[2], new Dictionary<int, string>());
                    }
                    indexes[commandArgs[2]].Add(i, names[i]);
                    names[i] = " ";
                }
            }
        }

        private static void AddFilterEndsWith(string[] names, Dictionary<string, Dictionary<int, string>> indexes, string[] commandArgs)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].EndsWith(commandArgs[2]))
                {
                    if (!indexes.ContainsKey(commandArgs[2]))
                    {
                        indexes.Add(commandArgs[2], new Dictionary<int, string>());
                    }
                    indexes[commandArgs[2]].Add(i, names[i]);
                    names[i] = " ";
                }
            }
        }

        private static void AddFilterStartsWith(string[] names, Dictionary<string, Dictionary<int, string>> indexes, string[] commandArgs)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].StartsWith(commandArgs[2]))
                {
                    if (!indexes.ContainsKey(commandArgs[2]))
                    {
                        indexes.Add(commandArgs[2], new Dictionary<int, string>());
                    }
                    indexes[commandArgs[2]].Add(i, names[i]);
                    names[i] = " ";
                }
            }
        }

        private static void RemoveFilter(string[] names, Dictionary<string, Dictionary<int, string>> indexes, string[] commandArgs)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == " " && indexes[commandArgs[2]].ContainsKey(i))
                {
                    names[i] = indexes[commandArgs[2]][i];
                }
            }
        }
    }
}