using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    public class StartUp
    {
        public static void Main()
        {
            var fuelQueue = new Queue<long>();
            var distanceQueue = new Queue<long>();
            int index = 0;
            int bestIndex = 0;
            bool isPotentialIndexFound = true;
            bool isIndexFound = false;
            long currentFuel = 0L;
            long numberOfPumps = long.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPumps; i++)
            {
                var currentPump = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                long fuel = currentPump[0];
                long distance = currentPump[1];

                fuelQueue.Enqueue(fuel);
                distanceQueue.Enqueue(distance);
            }
            while (true)
            {
                if (index >= fuelQueue.Count)
                {
                    break;
                }
                isPotentialIndexFound = true;
                if (fuelQueue.Peek() < distanceQueue.Peek())
                {
                    fuelQueue.Enqueue(fuelQueue.Dequeue());
                    distanceQueue.Enqueue(distanceQueue.Dequeue());
                    index++;
                }
                else
                {
                    currentFuel = fuelQueue.Peek() - distanceQueue.Peek();
                    for (int i = 0; i < distanceQueue.Count - 1; i++)
                    {
                        if (currentFuel < 0)
                        {
                            isIndexFound = false;
                            currentFuel = 0;
                            fuelQueue.Enqueue(fuelQueue.Dequeue());
                            distanceQueue.Enqueue(distanceQueue.Dequeue());
                            index++;
                            break;
                        }
                        else
                        {
                            if (isPotentialIndexFound)
                            {
                                bestIndex = index;
                                isPotentialIndexFound = false;
                                isIndexFound = true;
                            }
                            fuelQueue.Enqueue(fuelQueue.Dequeue());
                            currentFuel += fuelQueue.Peek();
                            distanceQueue.Enqueue(distanceQueue.Dequeue());
                            currentFuel -= distanceQueue.Peek();
                            index++;
                        }
                    }
                }
            }
            if (isIndexFound)
            {
                Console.WriteLine(bestIndex);
            }
        }
    }
}
