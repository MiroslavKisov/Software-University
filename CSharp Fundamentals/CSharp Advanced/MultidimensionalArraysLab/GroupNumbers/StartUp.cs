using System;
using System.Linq;

namespace GroupNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
            int[] sizes = new int[3];
            foreach (var number in numbers)
            {
                int remainder = Math.Abs(number % 3);
                sizes[remainder]++;
            }
            int[][] jagged = new int[3][];
            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = new int[sizes[i]];
            }
            int[] index = new int[3];
            foreach (var number in numbers)
            {
                var remainder = Math.Abs(number % 3);
                jagged[remainder][index[remainder]] = number;
                index[remainder]++;
            }
        }
    }
}
