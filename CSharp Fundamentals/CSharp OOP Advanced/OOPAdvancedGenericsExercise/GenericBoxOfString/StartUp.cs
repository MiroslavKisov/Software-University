using System;


public class StartUp
{
    public static void Main()
    {
        int numberOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStrings; i++)
        {
            string currentString = Console.ReadLine();
            var box = new Box<string>(currentString);
            Console.WriteLine(box);
        }
    }
}

