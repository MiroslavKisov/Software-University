using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumElement
{
    public class StartUp
    {
        public static void Main()
        {
            var numberOfQueries = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxStack = new Stack<int>();
            var maxNumber = int.MinValue;
            for (int i = 0; i < numberOfQueries; i++)
            {
                var currentQuery = Console.ReadLine();
                if (currentQuery.StartsWith("1"))
                {
                    var commandArgs = currentQuery
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var commandParam = commandArgs[0];
                    var element = int.Parse(commandArgs[1]);
                    stack.Push(element);
                    if (element > maxNumber)
                    {
                        maxNumber = element;
                        maxStack.Push(maxNumber);
                    }
                }
                else if (currentQuery.StartsWith("2"))
                {
                    if (stack.Pop() == maxNumber)
                    {
                        maxStack.Pop();
                        if (maxStack.Count != 0)
                        {
                            maxNumber = maxStack.Peek();
                        }
                        else
                        {
                            maxNumber = int.MinValue;
                        }
                    }
                }
                else if (currentQuery.StartsWith("3"))
                {
                    Console.WriteLine(maxNumber);
                }
            }
        }
    }
}