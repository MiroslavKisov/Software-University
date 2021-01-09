using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperation
{
    public class StartUp
    {
        public static void Main()
        {
            var parameters = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var sequence = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var stack = new Stack<int>();
            var N = parameters[0];
            var S = parameters[1];
            var X = parameters[2];
            for (int i = 0; i < N; i++)
            {
                stack.Push(sequence[i]);
            }
            for (int i = 0; i < S; i++)
            {
                stack.Pop();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                var smallestNumber = stack.ToArray().Min();
                Console.WriteLine(smallestNumber);
            }
        }
    }
}
