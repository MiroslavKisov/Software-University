using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var matrix = new string[sizes[0], sizes[1]];
            for (int i = 0; i < sizes[0]; i++)
            {
                for (int j = 0, k = i; j < sizes[1]; j++, k++)
                {
                    matrix[i, j] += alphabet[i];
                    matrix[i, j] += alphabet[k];
                    matrix[i, j] += alphabet[i];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
