using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var stack = new Stack<string>();
        string input;
        try
        {
            while ((input = Console.ReadLine()) != "END")
            {
                switch (input.Contains("Push"))
                {
                    case true:
                        var commandArgs = input
                                .Split(new string[] { " " }, StringSplitOptions.None)
                                .ToList();

                        var command = commandArgs[0];
                        commandArgs.RemoveAt(0);

                        var numbers = commandArgs.Select(x => x.Trim(',',' ')).ToList();
                        numbers.RemoveAll(x => x == "");
                        stack.Push(numbers);
                        break;
                    case false:
                        stack.Pop();
                        break;
                    default:
                        break;
                }
            }
            stack.PrintAll();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

