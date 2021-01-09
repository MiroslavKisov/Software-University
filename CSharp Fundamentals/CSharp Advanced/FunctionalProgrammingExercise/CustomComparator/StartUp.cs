using System;
using System.Linq;
using System.Collections.Generic;

namespace CustomComparator
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int, bool> comparatorEven = n => n % 2 == 0;
            Func<int, bool> comparatorOdd = n => n % 2 != 0;
            var evens = numbers.Where(comparatorEven).ToArray();
            var odds = numbers.Where(comparatorOdd).ToArray();
            Array.Sort(evens);
            Array.Sort(odds);
            Console.Write(string.Join(" ", evens) + " ");
            Console.Write(string.Join(" ", odds));
        }
    }
}
