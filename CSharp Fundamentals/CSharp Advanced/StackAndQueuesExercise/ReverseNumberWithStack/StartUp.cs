using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumberWithStack
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(input);
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}
