using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    public class StartUp
    {
        public static void Main()
        {
            int range = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                .Split(new string[] { }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> numbers = new List<int>();
            for (int i = 1; i <= range; i++)
            {
                bool isGood = true;
                for (int j = 0; j < dividers.Count; j++)
                {
                    if (i % dividers[j] != 0)
                    {
                        isGood = false;
                        break;
                    }
                }
                if (isGood)
                {
                    numbers.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
