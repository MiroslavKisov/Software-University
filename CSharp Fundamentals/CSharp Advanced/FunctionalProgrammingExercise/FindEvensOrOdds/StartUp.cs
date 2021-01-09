using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    public class StartUp
    {
        public static void Main()
        {
            Func<int, bool> checkEven = arr => arr % 2 == 0;
            Func<int, bool> checkOdd = arr => arr % 2 != 0;
            var intervals = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var numbers = new List<int>();
            for (int i = intervals[0]; i <= intervals[1]; i++)
            {
                numbers.Add(i);
            }
            var type = Console.ReadLine();
            if (type == "even")
            {
                numbers.Where(checkEven).ToList().ForEach(n => Console.Write(n + " "));
            }
            else if(type == "odd")
            {
                numbers.Where(checkOdd).ToList().ForEach(n => Console.Write(n + " "));
            }
        }
    }
}
