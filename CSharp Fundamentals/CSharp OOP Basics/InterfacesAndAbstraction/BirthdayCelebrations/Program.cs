using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<IID> subjects = new List<IID>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var inputArgs = input.Split();

            if (inputArgs[0] == "Pet")
            {
                string name = inputArgs[1];
                string birthDate = inputArgs[2];

                IID pet = new Pet(name, birthDate);

                subjects.Add(pet);
            }
            else if (inputArgs[0] == "Citizen")
            {
                string name = inputArgs[1];
                string birthDate = inputArgs[4];

                IID citizen = new Citizen(name, birthDate);

                subjects.Add(citizen);
            }
        }

        string targetYear = Console.ReadLine();

        var result = subjects.Where(s => s.BirthDate.EndsWith(targetYear)).ToList();

        foreach (var subject in result)
        {
            if (subject is Pet)
            {
                var pet = (Pet)subject;
                Console.WriteLine(pet.BirthDate);
            }
            else
            {
                var citizen = (Citizen)subject;
                Console.WriteLine(citizen.BirthDate);
            }
        }
    }
}

