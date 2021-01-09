using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
        Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


        while (true)
        {
            string command = Console.ReadLine();

            if (command == "Output")
            {
                break;
            }

            string[] tokens = command.Split();
            var departament = tokens[0];
            var firstName = tokens[1];
            var secondName = tokens[2];
            var pacient = tokens[3];
            var fullName = firstName + secondName;

            if (!doctors.ContainsKey(firstName + secondName))
            {
                doctors[fullName] = new List<string>();
            }
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }

            bool havePlace = departments[departament].SelectMany(x => x).Count() < 60;
            if (havePlace)
            {
                int room = 0;
                doctors[fullName].Add(pacient);
                for (int i = 0; i < departments[departament].Count; i++)
                {
                    if (departments[departament][i].Count < 3)
                    {
                        room = i;
                        break;
                    }
                }
                departments[departament][room].Add(pacient);
            }

        }

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "End")
            {
                break;
            }
            string[] args = command.Split();
            if (args.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[args[0]]
                    .Where(x => x.Count > 0)
                    .SelectMany(x => x)));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int room))
            {
                Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
            }
        }
    }
}

