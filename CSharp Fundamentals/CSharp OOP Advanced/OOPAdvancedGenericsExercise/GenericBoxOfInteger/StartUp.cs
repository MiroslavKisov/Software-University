using System;

public class StartUp
{
    public static void Main()
    {
        int numberOfIntegers = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfIntegers; i++)
        {
            int currentInteger = int.Parse(Console.ReadLine());
            var box = new Box<int>(currentInteger);
            Console.WriteLine(box);
        }
    }
}

