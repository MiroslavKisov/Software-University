using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

        int x = dimestions[0];
        int y = dimestions[1];

        int[,] matrix = new int[x, y];
        SetMatrixValues(x, y, matrix);

        long sum = 0;
        while (true)
        {
            string command = Console.ReadLine();

            if (command == "Let the Force be with you")
            {
                break;
            }

            int[] ivoS = command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] evil = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            SetEvilForcePath(matrix, evil);

            int ivoCoordX = ivoS[0];
            int ivoCoordY = ivoS[1];
            SetIvoPath(matrix, ref sum, ref ivoCoordX, ref ivoCoordY);
        }

        Console.WriteLine(sum);

    }

    private static void SetIvoPath(int[,] matrix, ref long sum, ref int ivoCoordX, ref int ivoCoordY)
    {
        while (ivoCoordX >= 0 && ivoCoordY < matrix.GetLength(1))
        {
            if (ivoCoordX >= 0 && ivoCoordX < matrix.GetLength(0) && ivoCoordY >= 0 && ivoCoordY < matrix.GetLength(1))
            {
                sum += matrix[ivoCoordX, ivoCoordY];
            }

            ivoCoordY++;
            ivoCoordX--;
        }
    }

    private static void SetEvilForcePath(int[,] matrix, int[] evil)
    {
        int evilCoordX = evil[0];
        int evilCoordY = evil[1];

        while (evilCoordX >= 0 && evilCoordY >= 0)
        {
            if (evilCoordX >= 0 && evilCoordX < matrix.GetLength(0) && evilCoordY >= 0 && evilCoordY < matrix.GetLength(1))
            {
                matrix[evilCoordX, evilCoordY] = 0;
            }
            evilCoordX--;
            evilCoordY--;
        }
    }

    private static void SetMatrixValues(int x, int y, int[,] matrix)
    {
        int value = 0;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                matrix[i, j] = value++;
            }
        }
    }
}

