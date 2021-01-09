using System;
using System.Linq;

namespace SumMatrixElements
{
    public class StartUp
    {
        public static void Main()
        {
            var sizes = Console.ReadLine()
                .Split(new string[] { "  " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[sizes[0],sizes[1]];
            int sum = 0;
            for (int rows = 0; rows < sizes[0]; rows++)
            {
                var values = Console.ReadLine().Split(new string[] { "  " },StringSplitOptions.None).Select(int.Parse).ToArray();
                sum += values.Sum();
                for (int cols = 0; cols < sizes[1]; cols++)
                {
                    matrix[rows, cols] = values[cols];
                }
            }
            Console.WriteLine(sizes[0]);
            Console.WriteLine(sizes[1]);
            Console.WriteLine(sum);
        }
    }
}
