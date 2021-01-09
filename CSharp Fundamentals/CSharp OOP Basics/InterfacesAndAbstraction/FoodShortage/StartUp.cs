using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<IBuyer> peoples = new List<IBuyer>();

        int numberOfPersons = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPersons; i++)
        {
            var inputArgs = Console.ReadLine()
                .Split();

            if (inputArgs.Length == 3)
            {
                string name = inputArgs[0];
                IBuyer rebel = new Rebel(name);

                peoples.Add(rebel);
            }
            else if (inputArgs.Length == 4)
            {
                string name = inputArgs[0];
                IBuyer citizen = new Citizen(name);

                peoples.Add(citizen);
            }
        }
        string command;
        int totalFood = 0;
        while ((command = Console.ReadLine()) != "End")
        {
            for (int i = 0; i < peoples.Count; i++)
            {
                if (peoples[i] is Citizen)
                {
                    var citizen = (Citizen)peoples[i];

                    if (citizen.Name == command)
                    {
                        totalFood += citizen.BuyFood();
                    }
                }
                else
                {
                    var rebel = (Rebel)peoples[i];

                    if (rebel.Name == command)
                    {
                        totalFood += rebel.BuyFood();
                    }
                }
            }
        }

        Console.WriteLine(totalFood);
    }
}

