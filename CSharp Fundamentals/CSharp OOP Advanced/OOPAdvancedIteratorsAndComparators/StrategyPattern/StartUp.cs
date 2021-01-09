using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var orderedByName = new SortedSet<Person>(new NameComparator());
        var orderedByAge = new SortedSet<Person>(new AgeComparator());

        int numberOfPersons = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPersons; i++)
        {
            var args = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string name = args[0];
            int age = int.Parse(args[1]);

            var person = new Person(name, age);

            orderedByName.Add(person);
            orderedByAge.Add(person);
        }

        Console.WriteLine(string.Join(Environment.NewLine, orderedByName));
        Console.WriteLine(string.Join(Environment.NewLine, orderedByAge));
    }
}

