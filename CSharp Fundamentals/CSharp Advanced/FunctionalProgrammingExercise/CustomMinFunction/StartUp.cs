using System;
using System.Linq;

namespace CustomMinFunction
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int[], int> findMin = arr => arr.Min();
            int min = findMin(input);
            Console.WriteLine(min);
        }
    }
}
