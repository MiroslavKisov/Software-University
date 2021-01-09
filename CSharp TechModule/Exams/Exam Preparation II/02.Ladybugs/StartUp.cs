using System;
using System.Linq;

namespace _02.Ladybugs
{
    public class StartUp
    {
        public static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine());
            var ladyBugIndexes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            bool[] field = new bool[fieldSize];
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < ladyBugIndexes.Length; j++)
                {
                    if (i == ladyBugIndexes[j])
                    {
                        field[i] = true;
                    }
                }
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                var commandArgs = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int startIndex = int.Parse(commandArgs[0]);
                string direction = commandArgs[1];
                int flightDistance = int.Parse(commandArgs[2]);
                if (startIndex < 0 || startIndex > field.Length - 1
                    || field[startIndex] == false || flightDistance == 0)
                {
                    continue;
                }
                if (direction == "right")
                {
                    if (flightDistance >= 0)
                    {
                        FlyRight(startIndex, field, flightDistance);
                    }
                    else
                    {
                        FlyLeft(startIndex, field, flightDistance);
                    }
                }
                else if (direction == "left")
                {
                    if (flightDistance >= 0)
                    {
                        FlyLeft(startIndex, field, flightDistance);
                    }
                    else
                    {
                        FlyRight(startIndex, field, flightDistance);
                    }
                }
            }
            PrintResult(field);
        }

        private static void PrintResult(bool[] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                if (field[i] == true)
                {
                    Console.Write(1 + " ");
                }
                else
                {
                    Console.Write(0 + " ");
                }
            }
        }

        private static void FlyLeft(int startIndex, bool[] field, int flightDistance)
        {
            bool isBugLanded = false;
            flightDistance = Math.Abs(flightDistance);
            for (int i = startIndex; i >= 0; i -= flightDistance)
            {
                if (field[i] == false)
                {
                    field[i] = true;
                    isBugLanded = true;
                }
                field[startIndex] = false;
                if (isBugLanded)
                {
                    return;
                }
            }
        }

        private static void FlyRight(int startIndex, bool[] field, int flightDistance)
        {
            bool isBugLanded = false;
            flightDistance = Math.Abs(flightDistance);
            for (int i = startIndex; i <= field.Length - 1; i += flightDistance)
            {
                if (field[i] == false)
                {
                    field[i] = true;
                    isBugLanded = true;
                }
                field[startIndex] = false;
                if (isBugLanded)
                {
                    return;
                }
            }
        }
    }
}
