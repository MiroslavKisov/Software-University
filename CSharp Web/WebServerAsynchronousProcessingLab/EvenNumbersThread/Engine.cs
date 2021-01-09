namespace EvenNumbersThread
{
    using System;
    using System.Linq;
    using System.Threading;

    public class Engine
    {
        public void Run()
        {
            var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int min = input[0];
            int max = input[1];

            Thread thread = new Thread(() => GetEvens(min, max));

            thread.Start();
            thread.Join();

            Console.WriteLine("Thread finished work.");
        }

        private void GetEvens(int min, int max)
        {
            for (int i = min; i < max; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
