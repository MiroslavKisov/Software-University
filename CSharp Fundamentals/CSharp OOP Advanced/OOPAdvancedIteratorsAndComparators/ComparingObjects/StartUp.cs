using System;
using System.Linq;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var persons = new List<Person>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var args = input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string name = args[0];
            int age = int.Parse(args[1]);
            string town = args[2];

            var person = new Person(name, age, town);

            persons.Add(person);
        }

        var personIndex = int.Parse(Console.ReadLine());

        GetStatistic(persons, personIndex);
    }

    private static void GetStatistic(List<Person> persons, int personIndex)
    {
        var targetPerson = persons[personIndex - 1];
        var equalPeople = 0;
        var differentPeople = 0;
        persons.Remove(targetPerson);

        foreach (var person in persons)
        {
            if (person.CompareTo(targetPerson) == 0)
            {
                equalPeople++;
            }
            else
            {
                differentPeople++;
            }
        }
        if (equalPeople == 0)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalPeople + 1} {differentPeople} {persons.Count + 1}");
        }
    }
}

