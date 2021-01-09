using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var box = new Box<string>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var commandArgs = input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = commandArgs.First();
            commandArgs.RemoveAt(0);

            switch (command)
            {
                case "Add":
                    box.AddValue(commandArgs[0]);
                    break;
                case "Max":
                    Console.WriteLine(box.Max());
                    break;
                case "Min":
                    Console.WriteLine(box.Min());
                    break;
                case "Remove":
                    box.Remove(int.Parse(commandArgs[0]));
                    break;
                case "Contains":
                    Console.WriteLine(box.Contains(commandArgs[0]));
                    break;
                case "Swap":
                    box.SwapValues(commandArgs.Select(int.Parse).ToArray());
                    break;
                case "Greater":
                    Console.WriteLine(box.CountGreaterThan(commandArgs[0]));
                    break;
                case "Print":
                    Console.WriteLine(box);
                    break;
                case "Sort":
                    Sorter<string>.Sort(box.Values);
                    break;
                default:
                    break;
            }
        }
    }
}
