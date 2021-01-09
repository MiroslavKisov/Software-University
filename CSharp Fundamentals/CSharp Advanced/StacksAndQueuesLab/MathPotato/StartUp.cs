using System;
using System.Collections.Generic;

namespace MathPotato
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var number = int.Parse(Console.ReadLine());
            var players = input.Split(' ');
            int counter = 1;
            var queue = new Queue<string>(players);
            while(queue.Count != 1)
            {
                for (int i = 1; i < number; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                if (IsPrime(counter))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                counter++;
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }
            int range = (int)Math.Sqrt(number);
            for (int i = 2; i <= range; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
