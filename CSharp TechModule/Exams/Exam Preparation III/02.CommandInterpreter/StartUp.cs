using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CommandInterpreter
{
    public class StartUp
    {
        public static void Main()
        {
            var inputData = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                if (command.Contains("reverse from"))
                {
                    var reverseCommand = command
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    Reverse(inputData, reverseCommand[2], reverseCommand[4]);
                }
                else if (command.Contains("rollLeft"))
                {
                    var rollLeftCommand = command
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    RollLeft(inputData, rollLeftCommand[1]);
                }
                else if (command.Contains("rollRight"))
                {
                    var rollRightCommand = command
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    RollRight(inputData, rollRightCommand[1]);
                }
                else if (command.Contains("sort from"))
                {
                    var sortCommand = command
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    SortInRange(inputData, sortCommand[2], sortCommand[4]);
                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", inputData));
        }

        private static string[] SortInRange(string[] inputData, string v1, string v2)
        {
            int start = int.Parse(v1);
            int count = int.Parse(v2);
            if (start < 0 || start >= inputData.Length || count < 0 || start + count > inputData.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return inputData;
            }
            else
            {
                var leftSide = inputData.Take(start).ToArray();
                var middleSide = inputData.Skip(start).Take(count).OrderBy(x => x).ToArray();
                var rightSide = inputData.Skip(start + count).Take(inputData.Length - (start + count)).ToArray();
                var sortedArr = new string[inputData.Length];
                leftSide.CopyTo(sortedArr, 0);
                middleSide.CopyTo(sortedArr, leftSide.Length);
                rightSide.CopyTo(sortedArr, middleSide.Length+leftSide.Length);
                sortedArr.CopyTo(inputData, 0);
            }
            return inputData;
        }

        private static string[] RollRight(string[] inputData, string v)
        {
            int count = int.Parse(v);
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return inputData;
            }
            else
            {
                int range = 0;
                range= count % inputData.Length;
                if (range == 0)
                {
                    return inputData;
                }
                string[] shifted = new string[inputData.Length];
                for (int j = 0; j < range; j++)
                {
                    for (int i = 0; i < inputData.Length; i++)
                    {
                        shifted[(i + 1) % inputData.Length] = inputData[i];
                    }
                    shifted.CopyTo(inputData, 0);
                }
                shifted.CopyTo(inputData, 0);
                return inputData;
            }
        }

        private static string[] RollLeft(string[] inputData, string v)
        {
            int count = int.Parse(v);
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return inputData;
            }
            else
            {
                int range = 0;
                range = count % inputData.Length;
                if(range == 0)
                {
                    return inputData;
                }
                string[] shifted = new string[inputData.Length];
                for (int j = 0; j < range; j++)
                {
                    for (int i = 0; i < inputData.Length; i++)
                    {
                        shifted[i] = inputData[(i + 1) % inputData.Length];
                    }
                    shifted.CopyTo(inputData, 0);
                }
                shifted.CopyTo(inputData, 0);
                return inputData;
            }
        }

        private static string[] Reverse(string[] inputData, string v1, string v2)
        {
            int start = int.Parse(v1);
            int count = int.Parse(v2);
            if (start < 0 || start >= inputData.Length || count < 0 || start + count > inputData.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return inputData;
            }
            else
            {
                string swap = string.Empty;
                for (int i = 0; i < count / 2; i++)
                {
                    swap = inputData[start + i];
                    inputData[start + i] = inputData[start + count - i - 1];
                    inputData[start + count - i - 1] = swap;
                }
            }
            return inputData;
        }
    }
}
