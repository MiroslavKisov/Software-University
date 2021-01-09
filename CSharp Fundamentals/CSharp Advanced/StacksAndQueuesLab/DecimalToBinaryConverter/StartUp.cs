using System;
using System.Collections.Generic;

namespace DecimalToBinaryConverter
{
    public class StartUp
    {
        public static void Main()
        {
            var inputDecimal = int.Parse(Console.ReadLine());
            var stackBinary = new Stack<int>();
            if (inputDecimal == 0)
            {
                Console.WriteLine(0);
                return;
            }
            while(inputDecimal != 0)
            {
                var currentNumber = inputDecimal % 2;
                inputDecimal /= 2;
                stackBinary.Push(currentNumber);
            }
            var count = stackBinary.Count;
            for (int i = 0; i < count; i++)
            {
                Console.Write(stackBinary.Pop());
            }
        }
    }
}
