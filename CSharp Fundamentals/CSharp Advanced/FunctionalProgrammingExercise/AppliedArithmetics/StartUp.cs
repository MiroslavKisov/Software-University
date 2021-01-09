using System;
using System.Linq;
using System.Collections.Generic;

namespace AppliedArithmetics
{
    public class StartUp
    {
        public static void Main()
        {
            Func<int, int> subtract = n => n -= 1;
            Func<int, int> add = n => n += 1;
            Func<int, int> multuply = n => n *= 2;
            Action<List<int>> print = arr => Console.WriteLine(string.Join(" ", arr));
            var numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command;
            while((command = Console.ReadLine()) != "end")
            {
                if (command == "subtract")
                {
                   numbers = numbers.Select(subtract).ToList();
                }
                else if (command == "add")
                {
                    numbers = numbers.Select(add).ToList();
                }
                else if(command == "multiply")
                {
                    numbers = numbers.Select(multuply).ToList();
                }
                else if(command == "print")
                {
                    print(numbers);
                }
            }
        }
    }
}
