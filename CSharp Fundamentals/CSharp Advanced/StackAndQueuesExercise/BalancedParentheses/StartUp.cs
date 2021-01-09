using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            var parentheses = new Queue<char>(input);
            var counter = 0;
            char firstParent = ' ';
            char secondParent = ' ';
            bool isBalanced = true;
            bool isFound = false;
            if (parentheses.Count > 1 && parentheses.Count % 2 != 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                for (int i = 0; i < parentheses.Count; i++)
                {
                    counter = 0;
                    firstParent = parentheses.Peek();
                    if (firstParent == '(' || firstParent == '[' || firstParent == '{')
                    {
                        isBalanced = CheckOpen(parentheses, ref counter, firstParent, secondParent);
                        ResetPossition(parentheses, ref counter);
                    }
                    else if (firstParent == ')' || firstParent == ']' || firstParent == '}')
                    {
                        isBalanced = CheckClosed(parentheses, ref counter, firstParent, secondParent);
                        ResetPossition(parentheses, ref counter);
                    }
                }
                if (isBalanced)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }

        private static void ResetPossition(Queue<char> parentheses, ref int counter)
        {
            for (int i = 0; i < counter; i++)
            {
                parentheses.Enqueue(parentheses.Dequeue());
            }
        }

        private static bool CheckClosed(Queue<char> parentheses, ref int counter, char firstParent, char secondParent)
        {
            parentheses.Enqueue(parentheses.Dequeue());
            for (int i = 0; i < parentheses.Count; i++)
            {
                secondParent = parentheses.Peek();
                if (firstParent == ')' && secondParent == '(' && counter % 2 == 0)
                {
                    return true;
                }
                else if (firstParent == '}' && secondParent == '{' && counter % 2 == 0)
                {
                    return true;
                }
                else if (firstParent == ']' && secondParent == '[' && counter % 2 == 0)
                {
                    return true;
                }
                else
                {
                    parentheses.Enqueue(parentheses.Dequeue());
                    counter++;
                }
            }
            return false;
        }

        private static bool CheckOpen(Queue<char> parentheses, ref int counter, char firstParent, char secondParent)
        {
            parentheses.Enqueue(parentheses.Dequeue());
            for (int i = 0; i < parentheses.Count; i++)
            {
                secondParent = parentheses.Peek();
                if (firstParent == '(' && secondParent == ')' && counter % 2 == 0)
                {
                    return true;
                }
                else if (firstParent == '{' && secondParent == '}' && counter % 2 == 0)
                {
                    return true;
                }
                else if (firstParent == '[' && secondParent == ']' && counter % 2 == 0)
                {
                    return true;
                }
                else
                {
                    parentheses.Enqueue(parentheses.Dequeue());
                    counter++;
                }
            }
            return false;
        }
    }
}
