using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var listEnumerator = new ListEnumerator<string>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var args = input.Split().ToList();
            var command = args[0];

            args.RemoveAt(0);

            try
            {
                switch (command)
                {
                    case "Create":
                        listEnumerator.Create(args);
                        break;
                    case "Move":
                        Console.WriteLine(listEnumerator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listEnumerator.HasNext());
                        break;
                    case "Print":
                        listEnumerator.Print();
                        break;
                    case "PrintAll":
                        listEnumerator.PrintAll();
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

