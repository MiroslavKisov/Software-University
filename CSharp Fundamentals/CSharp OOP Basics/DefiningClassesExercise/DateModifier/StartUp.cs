using System;

public class StartUp
{
    public static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();
        DateModifier dateModifier = new DateModifier(firstDate, secondDate);
        TimeSpan result = dateModifier.CalculateDifference(firstDate, secondDate);
        Console.WriteLine($"{result.Days}");
    }
}

