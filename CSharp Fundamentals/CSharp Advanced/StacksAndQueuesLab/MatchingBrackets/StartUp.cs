using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    public static class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();          
            var stackWithIndexes = new Stack<int>();
            int startIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stackWithIndexes.Push(i);
                }
                else if(input[i] == ')')
                {
                    startIndex = stackWithIndexes.Pop();
                    var subPattern = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(subPattern);
                }
            }
        }
    }
}
