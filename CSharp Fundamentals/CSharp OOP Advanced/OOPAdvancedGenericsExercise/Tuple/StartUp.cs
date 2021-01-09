using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string[] args = ReadData();

        var tuple1 = new Tuple<string, string>(args[0] + " " + args[1], args[2]);
        Console.WriteLine(tuple1);

        args = ReadData();

        var tuple2 = new Tuple<string, int>(args[0], int.Parse(args[1]));
        Console.WriteLine(tuple2);

        args = ReadData();

        var tuple3 = new Tuple<int, double>(int.Parse(args[0]), double.Parse(args[1]));
        Console.WriteLine(tuple3);

    }

    private static string[] ReadData()
    {
        string input = Console.ReadLine();
        var args = input
            .Split();
        return args;
    }
}

