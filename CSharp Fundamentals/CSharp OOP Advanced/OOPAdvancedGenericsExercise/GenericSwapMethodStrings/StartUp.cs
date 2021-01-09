using System;
using System.Linq;


public class StartUp
{
    public static void Main()
    {
        var box = new Box<string>();
        int numberOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStrings; i++)
        {
            string currentString = Console.ReadLine();
            box.AddValue(currentString);
        }

        var swapParams = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        box.SwapValues(swapParams);
        Console.WriteLine(box);
    }
}

