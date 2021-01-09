using System;

public class StartUp
{
    public static void Main()
    {
        var box = new Box<string>();
        int numberOfElements = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfElements; i++)
        {
            string element = Console.ReadLine();
            box.AddValue(element);
        }
        string elementToCompare = Console.ReadLine();

        int count = box.CountGreaterThan(elementToCompare);

        Console.WriteLine(count);
    }
}

