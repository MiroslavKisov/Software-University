using System;
using System.Collections.Generic;

namespace ReverseString
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            input.ToCharArray();
            Stack<char> stack = new Stack<char>(input);
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
