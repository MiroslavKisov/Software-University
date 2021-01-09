using System;

public class StartUp
{
    public static void Main()
    {
        Family family = new Family();
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine();
            var commandArgs = input
            .Split(new string[] { }, StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(commandArgs[0], int.Parse(commandArgs[1]));
            family.AddMember(person);
        }
        Person prs = family.GetOldestMember();
        Console.WriteLine($"{prs.Name} {prs.Age}");
    }
}

