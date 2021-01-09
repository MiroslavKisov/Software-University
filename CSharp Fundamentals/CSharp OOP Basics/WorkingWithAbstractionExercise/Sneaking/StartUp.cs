using System;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[][] room = new char[n][];
        SettingTheRoom(n, room);

        var moves = Console.ReadLine().ToCharArray();

        int[] samPosition = new int[2];

        SettingSamPossition(room, samPosition);

        for (int i = 0; i < moves.Length; i++)
        {
            MoveEnemy(room);

            int[] getEnemy = new int[2];
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
            CheckingIfSamIsAlive(room, samPosition, getEnemy);

            room[samPosition[0]][samPosition[1]] = '.';

            MoveSam(moves, samPosition, i);

            room[samPosition[0]][samPosition[1]] = 'S';

            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
            CheckingIfNikoladzeIsKilled(room, samPosition, getEnemy);
        }
    }

    public static void CheckingIfNikoladzeIsKilled(char[][] room, int[] samPosition, int[] getEnemy)
    {
        if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
        {
            room[getEnemy[0]][getEnemy[1]] = 'X';
            Console.WriteLine("Nikoladze killed!");
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }
    }

    public static void CheckingIfSamIsAlive(char[][] room, int[] samPosition, int[] getEnemy)
    {
        if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
        {
            room[samPosition[0]][samPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }
        else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
        {
            room[samPosition[0]][samPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }
    }

    public static void MoveSam(char[] moves, int[] samPosition, int i)
    {
        switch (moves[i])
        {
            case 'U':
                samPosition[0]--;
                break;
            case 'D':
                samPosition[0]++;
                break;
            case 'L':
                samPosition[1]--;
                break;
            case 'R':
                samPosition[1]++;
                break;
            default:
                break;
        }
    }

    public static void MoveEnemy(char[][] room)
    {
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'b')
                {
                    if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                    {
                        room[row][col] = '.';
                        room[row][col + 1] = 'b';
                        col++;
                    }
                    else
                    {
                        room[row][col] = 'd';
                    }
                }
                else if (room[row][col] == 'd')
                {
                    if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                    {
                        room[row][col] = '.';
                        room[row][col - 1] = 'd';
                    }
                    else
                    {
                        room[row][col] = 'b';
                    }
                }
            }
        }
    }

    public static void SettingSamPossition(char[][] room, int[] samPosition)
    {
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'S')
                {
                    samPosition[0] = row;
                    samPosition[1] = col;
                }
            }
        }
    }

    public static void SettingTheRoom(int n, char[][] room)
    {
        for (int row = 0; row < n; row++)
        {
            var input = Console.ReadLine().ToCharArray();
            room[row] = new char[input.Length];
            for (int col = 0; col < input.Length; col++)
            {
                room[row][col] = input[col];
            }
        }
    }
}

