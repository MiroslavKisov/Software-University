using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    public class StartUp
    {
        public static void Main()
        {
            var size = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var snake = Console.ReadLine();
            var shot = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var shotCoordX = shot[0];
            var shotCoordY = shot[1];
            var shotRadius = shot[2];
            var matrix = new char[size[0], size[1]];
            var index = 0;
            var shotIndexes = new List<List<int>>();
            for (int i = matrix.GetLength(0) - 1; i > 0; i --)
            {
                for (int j = matrix.GetLength(1) - 1; j > 0; j--)
                {
                    SetValuesLeft(matrix, ref i, ref j, snake, index);
                    index++;
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    SetValuesRight(matrix, ref i, ref j, snake, index);
                    index++;
                }
            }
            PrintMatrix(matrix);
            shotIndexes.Add(new List<int>());
            shotIndexes[0].Add(shotCoordX);
            shotIndexes[0].Add(shotCoordY);
            SetNorth(shotCoordX, shotCoordY, shotIndexes, shotRadius);
            SetSouth(shotCoordX, shotCoordY, shotIndexes, shotRadius, matrix);
            SetWest(shotCoordX, shotCoordY, shotIndexes, shotRadius);
            SetEast(shotCoordX, shotCoordY, shotIndexes, shotRadius, matrix);
            SetNorthEast(shotCoordX, shotCoordY, shotIndexes, shotRadius, matrix);
            SetNorthWest(shotCoordX, shotCoordY, shotIndexes, shotRadius, matrix);
            SetSouthWest(shotCoordX, shotCoordY, shotIndexes, shotRadius, matrix);
            SetSouthEast(shotCoordX, shotCoordY, shotIndexes, shotRadius, matrix);
            bool isIndex = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    isIndex = TakeTheShot(shotIndexes, i, j);
                    if (isIndex)
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == ' ' && i != 0)
                    {
                        RearangeMatrix(matrix,i,j);
                    }
                }
            }
            PrintMatrix(matrix);
        }

        private static void SetValuesRight(char[,] matrix, ref int i, ref int j, string snake, int index)
        {
            for (int k = index; k < index + 1; k++)
            {
                matrix[i, j] = snake[k];
            }
        }

        private static void SetValuesLeft(char[,] matrix, ref int i, ref int j, string snake, int index)
        {
            for (int k = index; k < index + 1; k++)
            {
                matrix[i, j] = snake[k];
            }
        }

        private static void RearangeMatrix(char[,] matrix, int i, int j)
        {
            var temp = ' ';
            var X = i;
            var Y = j;
            for (int k = i, m = 1, p = 0; k > 0; k--, m++, p++)
            {
                temp = matrix[X - m, Y];
                matrix[X - m, Y] = matrix[X - p, Y];
                matrix[X - p, Y] = temp;
            }
        }

        private static bool TakeTheShot(List<List<int>> shotIndexes, int i, int j)
        {
            for (int k = 0; k < shotIndexes.Count; k++)
            {
                if (shotIndexes[k][0] == i && shotIndexes[k][1] == j)
                {
                    return true;
                }
            }
            return false;
        }

        private static void SetSouthEast(int shotCoordX, int shotCoordY, List<List<int>> shotIndexes, int shotRadius, char[,] matrix)
        {
            var northEndPointCoordX = shotCoordX + shotRadius;
            var northEndPointCoordY = shotCoordY;
            var count = shotIndexes.Count;
            var index = shotIndexes.Count;
            var helper = 1;
            for (int j = 0; j < shotRadius - 1; j++)
            {
                for (int i = count; i < count + (shotRadius - helper); i++)
                {
                    northEndPointCoordX--;
                    northEndPointCoordY++;
                    shotIndexes.Add(new List<int>());
                    shotIndexes[index].Add(northEndPointCoordX);
                    shotIndexes[index].Add(northEndPointCoordY);
                    index++;
                }
                northEndPointCoordX = shotCoordX + shotRadius;
                northEndPointCoordY = shotCoordY;
                northEndPointCoordX--;
                helper++;
            }
        }

        private static void SetSouthWest(int shotCoordX, int shotCoordY, List<List<int>> shotIndexes, int shotRadius, char[,] matrix)
        {
            var northEndPointCoordX = shotCoordX + shotRadius;
            var northEndPointCoordY = shotCoordY;
            var count = shotIndexes.Count;
            var index = shotIndexes.Count;
            var helper = 1;
            for (int j = 0; j < shotRadius - 1; j++)
            {
                for (int i = count; i < count + (shotRadius - helper); i++)
                {
                    northEndPointCoordX--;
                    northEndPointCoordY--;
                    shotIndexes.Add(new List<int>());
                    shotIndexes[index].Add(northEndPointCoordX);
                    shotIndexes[index].Add(northEndPointCoordY);
                    index++;
                }
                northEndPointCoordX = shotCoordX + shotRadius;
                northEndPointCoordY = shotCoordY;
                northEndPointCoordX--;
                helper++;
            }
        }

        private static void SetNorthWest(int shotCoordX, int shotCoordY, List<List<int>> shotIndexes, int shotRadius, char[,] matrix)
        {
            var northEndPointCoordX = shotCoordX - shotRadius;
            var northEndPointCoordY = shotCoordY;
            var count = shotIndexes.Count;
            var index = shotIndexes.Count;
            var helper = 1;
            for (int j = 0; j < shotRadius - 1; j++)
            {
                for (int i = count; i < count + (shotRadius - helper); i++)
                {
                    northEndPointCoordX++;
                    northEndPointCoordY--;
                    shotIndexes.Add(new List<int>());
                    shotIndexes[index].Add(northEndPointCoordX);
                    shotIndexes[index].Add(northEndPointCoordY);
                    index++;
                }
                northEndPointCoordX = shotCoordX - shotRadius;
                northEndPointCoordY = shotCoordY;
                northEndPointCoordX++;
                helper++;
            }
        }

        private static void SetNorthEast(int shotCoordX, int shotCoordY, List<List<int>> shotIndexes, int shotRadius, char[,] matrix)
        {
            var northEndPointCoordX = shotCoordX - shotRadius;
            var northEndPointCoordY = shotCoordY;
            var eastEndPointCoordX = shotCoordX;
            var eastEndPointCoordY = shotCoordY + shotRadius;
            var count = shotIndexes.Count;
            var index = shotIndexes.Count;
            var helper = 1;
            for (int j = 0; j < shotRadius - 1; j++)
            {
                for (int i = count; i < count + (shotRadius - helper); i++)
                {
                    northEndPointCoordX++;
                    northEndPointCoordY++;
                    shotIndexes.Add(new List<int>());
                    shotIndexes[index].Add(northEndPointCoordX);
                    shotIndexes[index].Add(northEndPointCoordY);
                    index++;
                }
                northEndPointCoordX = shotCoordX - shotRadius;
                northEndPointCoordY = shotCoordY;
                northEndPointCoordX++;
                helper++;
            }
        }

        private static void SetEast(int shotCoordX, int shotCoordY, List<List<int>> shotIndexes, int shotRadius, char[,] matrix)
        {
            var count = shotIndexes.Count;
            for (int i = count; i < shotRadius + count; i++)
            {
                shotCoordY++;
                if (shotCoordY > matrix.GetLength(1) - 1)
                {
                    break;
                }
                else
                {
                    shotIndexes.Add(new List<int>());
                    shotIndexes[i].Add(shotCoordX);
                    shotIndexes[i].Add(shotCoordY);
                }
            }
        }

        private static void SetWest(int shotCoordX, int shotCoordY, List<List<int>> shotIndexes, int shotRadius)
        {
            var count = shotIndexes.Count;
            for (int i = count; i < shotRadius + count; i++)
            {
                shotCoordY--;
                if (shotCoordY < 0)
                {
                    break;
                }
                else
                {
                    shotIndexes.Add(new List<int>());
                    shotIndexes[i].Add(shotCoordX);
                    shotIndexes[i].Add(shotCoordY);
                }
            }
        }

        private static void SetSouth(int shotCoordX, int shotCoordY, List<List<int>> shotIndexes, int shotRadius, char[,] matrix)
        {
            var count = shotIndexes.Count;
            for (int i = count; i < shotRadius + count; i++)
            {
                shotCoordX++;
                if (shotCoordX > matrix.GetLength(0) - 1)
                {
                    break;
                }
                else
                {
                    shotIndexes.Add(new List<int>());
                    shotIndexes[i].Add(shotCoordX);
                    shotIndexes[i].Add(shotCoordY);
                }
            }
        }

        private static void SetNorth(int shotCoordX, int shotCoordY, List<List<int>> shotIndexes, int shotRadius)
        {
            var count = shotIndexes.Count;
            for (int i = count; i < shotRadius + count; i++)
            {
                shotCoordX--;
                if (shotCoordX < 0)
                {
                    break;
                }
                else
                {
                    shotIndexes.Add(new List<int>());
                    shotIndexes[i].Add(shotCoordX);
                    shotIndexes[i].Add(shotCoordY);
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}