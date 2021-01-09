using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            var reminder = input.Split(' ');
            Stack<string> stack = new Stack<string>(reminder.Reverse());
            int currentSum = int.Parse(stack.Pop());
            while (stack.Count > 0)
            {
                var op = stack.Pop();
                string currentNumber = stack.Pop();
                if (op == "+")
                {
                    currentSum += int.Parse(currentNumber);
                }
                else
                {
                    currentSum -= int.Parse(currentNumber);
                }
            }
            Console.WriteLine(currentSum);
        }
    }
}
