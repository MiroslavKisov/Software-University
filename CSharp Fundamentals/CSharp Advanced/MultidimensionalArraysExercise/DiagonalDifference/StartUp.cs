using System;
using System.Linq;

namespace DiagonalDifference
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            long[,] matrix = new long[N, N];
            long sumPrimary = 0;
            long sumSecondary = 0;
            long difference = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var line = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            for (int i = 0, j = 0, k = 0; i < N; i++, j++, k++)
            {
                sumPrimary += matrix[j, k]; 
            }
            for (int i = 0, j = 0, k = N - 1; i < N; i++, j++, k--)
            {
                sumSecondary += matrix[j, k];
            }
            difference = sumPrimary - sumSecondary;
            Console.WriteLine(Math.Abs(difference));
        }
    }
}
