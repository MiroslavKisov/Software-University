using System;

public class StartUp
{
    public static void Main()
    {
        Family family = new Family();
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string command = Console.ReadLine();
            var commandArgs = command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(commandArgs[0], int.Parse(commandArgs[1]));
            family.AddMember(person);
        }
        var prsn = family.GetOldestThan30();
        foreach (var p in prsn)
        {
            Console.WriteLine($"{p.Name} - {p.Age}");
        }
    }
}

