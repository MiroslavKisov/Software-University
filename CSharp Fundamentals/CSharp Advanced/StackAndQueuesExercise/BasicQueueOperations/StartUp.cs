using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicQueueOperations
{
    public class StartUp
    {
        public static void Main()
        {
            var queue = new Queue<int>();
            var commandParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int N = commandParams[0];
            int S = commandParams[1];
            int X = commandParams[2];
            for (int i = 0; i < N; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < S; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
