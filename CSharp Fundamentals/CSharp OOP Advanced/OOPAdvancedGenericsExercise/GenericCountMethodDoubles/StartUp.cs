using System;

public class StartUp
{
    public static void Main()
    {
        var box = new Box<double>();
        int numberOfElements = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfElements; i++)
        {
            double element = double.Parse(Console.ReadLine());
            box.AddValue(element);
        }
        double elementToCompare = double.Parse(Console.ReadLine());

        int count = box.CountGreaterThan(elementToCompare);

        Console.WriteLine(count);
    }
}

