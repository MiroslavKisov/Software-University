using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var persons = new Dictionary<string, Person>();
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "End")
            {
                break;
            }
            var commandArgs = command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string personName = commandArgs[0];
            if (commandArgs[1] == "company")
            {
                string companyName = commandArgs[2];
                string department = commandArgs[3];
                decimal salary = decimal.Parse(commandArgs[4]);
                if (!persons.ContainsKey(personName))
                {
                    Person person = new Person(personName);
                    Company company = new Company(companyName, department, salary);
                    person.Company = company;
                    persons.Add(personName, person);
                }
                else
                {
                    Company company = new Company(companyName, department, salary);
                    persons[personName].Company = company;
                }
            }
            else if (commandArgs[1] == "car")
            {
                string model = commandArgs[2];
                string speed = commandArgs[3];
                if (!persons.ContainsKey(personName))
                {
                    Person person = new Person(personName);
                    Car car = new Car(model, speed);
                    person.Car = car;
                    persons.Add(personName, person);
                }
                else
                {
                    Car car = new Car(model, speed);
                    persons[personName].Car = car;
                }
            }
            else if (commandArgs[1] == "pokemon")
            {
                string pokemonName = commandArgs[2];
                string pokemonPower = commandArgs[3];
                if (!persons.ContainsKey(personName))
                {
                    Person person = new Person(personName);
                    Pokemon pokemon = new Pokemon(pokemonName, pokemonPower);
                    person.Pokemons.Add(pokemon);
                    persons.Add(personName, person);
                }
                else
                {
                    Pokemon pokemon = new Pokemon(pokemonName, pokemonPower);
                    persons[personName].Pokemons.Add(pokemon);
                }
            }
            else if (commandArgs[1] == "parents")
            {
                string parentName = commandArgs[2];
                string parentBirthDate = commandArgs[3];
                if (!persons.ContainsKey(personName))
                {
                    Person person = new Person(personName);
                    Parent parent = new Parent(parentName, parentBirthDate);
                    person.Parents.Add(parent);
                    persons.Add(personName, person);
                }
                else
                {
                    Parent parent = new Parent(parentName, parentBirthDate);
                    persons[personName].Parents.Add(parent);
                }
            }
            else if (commandArgs[1] == "children")
            {
                string childName = commandArgs[2];
                string childBirthDate = commandArgs[3];
                if (!persons.ContainsKey(personName))
                {
                    Person person = new Person(personName);
                    Child child = new Child(childName, childBirthDate);
                    person.Children.Add(child);
                    persons.Add(personName, person);
                }
                else
                {
                    Child child = new Child(childName, childBirthDate);
                    persons[personName].Children.Add(child);
                }
            }
        }
        string printName = Console.ReadLine();
        if (persons.ContainsKey(printName))
        {
            PrintResult(printName, persons);
        }
    }

    private static void PrintResult(string printName, Dictionary<string, Person> persons)
    {
        Console.WriteLine(printName);
        Console.WriteLine("Company:");
        if (persons[printName].Company != null)
        {
            Console.WriteLine(persons[printName].Company);
        }
        Console.WriteLine("Car:");
        if (persons[printName].Car != null)
        {
            Console.WriteLine(persons[printName].Car);
        }
        Console.WriteLine("Pokemon:");
        foreach (var pokemon in persons[printName].Pokemons)
        {
            Console.WriteLine(pokemon);
        }
        Console.WriteLine("Parents:");
        foreach (var parent in persons[printName].Parents)
        {
            Console.WriteLine(parent);
        }
        Console.WriteLine("Children:");
        foreach (var child in persons[printName].Children)
        {
            Console.WriteLine(child);
        }
    }
}

