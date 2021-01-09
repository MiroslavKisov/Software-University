using System;
using System.Linq;

namespace ReverseAndExclude
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int number = int.Parse(Console.ReadLine());
            input = input.Where(n => n % number != 0).ToArray();
            Array.Reverse(input);
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
