using System;
using System.Collections.Generic;

namespace CalculateSequenceWithQueue
{
    public class StartUp
    {
        public static void Main()
        {
            var queue = new Queue<long>();
            long startNumber = long.Parse(Console.ReadLine());
            long nextNumber = 0;
            long counter = 0;
            Console.Write(startNumber + " ");
            for (int i = 0; i < 50; i++)
            {
                counter++;
                nextNumber = startNumber + 1;
                queue.Enqueue(nextNumber);
                Console.Write(nextNumber + " ");

                if (counter == 49)
                {
                    break;
                }

                counter++;
                nextNumber = startNumber * 2 + 1;
                queue.Enqueue(nextNumber);
                Console.Write(nextNumber + " ");

                if (counter == 49)
                {
                    break;
                }

                counter++;
                nextNumber = startNumber + 2;
                queue.Enqueue(nextNumber);
                Console.Write(nextNumber + " ");

                if (counter == 49)
                {
                    break;
                }

                startNumber = queue.Dequeue();
            }
        }
    }
}
