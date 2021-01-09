using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {

        var numbers = Console.ReadLine()
            .Split(new char[] {',',' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        var lake = new Lake(numbers);
        Console.WriteLine(string.Join(", ", lake));
    }
}

