using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    public class StartUp
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var stack = new Stack<long>();
            long firstFibo = 0;
            long secondFibo = 1;
            long nthFibo = 0;
            stack.Push(secondFibo);
            stack.Push(firstFibo);
            for (int i = 0; i < N - 1; i++)
            {
                firstFibo = stack.Pop();
                secondFibo = stack.Pop();
                nthFibo = firstFibo + secondFibo;
                stack.Push(nthFibo);
                stack.Push(secondFibo);
            }
            Console.WriteLine(nthFibo);
        }
    }
}
