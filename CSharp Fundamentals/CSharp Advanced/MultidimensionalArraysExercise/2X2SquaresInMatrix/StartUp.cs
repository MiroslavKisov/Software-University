using System;
using System.Linq;

namespace _2X2SquaresInMatrix
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new char[size[0], size[1]];
            var counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var rows = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rows[j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] 
                        && matrix[i, j] == matrix[i + 1, j] 
                        && matrix[i ,j] == matrix[i + 1,j + 1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter++);
        }
    }
}
