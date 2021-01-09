using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    public class StartUp
    {
        public static void Main()
        {
            var numberOfCommands = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            var text = new StringBuilder();
            stack.Push("");
            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0].StartsWith("1"))
                {
                    stack.Push(text.ToString());
                    text.Append(command[1]);
                }
                else if (command[0].StartsWith("2"))
                {
                    stack.Push(text.ToString());
                    var count = int.Parse(command[1]);
                    text.Remove(text.Length - count, count);
                }
                else if (command[0].StartsWith("3"))
                {
                    var index = int.Parse(command[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command[0].StartsWith("4"))
                {
                    text.Clear();
                    text.Append(stack.Pop());
                }
            }
        }
    }
}
