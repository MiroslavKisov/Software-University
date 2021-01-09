using System;
using System.Linq;

namespace MaximalSum
{
    public class StartUp
    {
        public static void Main()
        {
            var sizes = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
            var matrix = new long[sizes[0], sizes[1]];
            long currentSum = 0;
            var bestSum = long.MinValue;
            int X = 0;
            int Y = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var rows = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rows[j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                        + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                        + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        X = i;
                        Y = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[X + i,Y + j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
