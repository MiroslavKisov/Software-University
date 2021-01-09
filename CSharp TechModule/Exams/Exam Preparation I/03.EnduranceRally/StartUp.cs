using System;
using System.Linq;

namespace _03.EnduranceRally
{
    public class StartUp
    {
        public static void Main()
        {
            var drivers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var track = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            var checkpoints = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            for (int i = 0; i < drivers.Count; i++)
            {
                int distanceReached = 0;
                double driverFuel = drivers[i][0];
                for (int j = 0; j < track.Count; j++)
                {
                    if (driverFuel <= 0)
                    {
                        break;
                    }
                    bool isCheckPoint = false;
                    for (int k = 0; k < checkpoints.Count; k++)
                    {
                        if (j == checkpoints[k])
                        {
                            isCheckPoint = true;
                            break;
                        }
                    }
                    if (isCheckPoint)
                    {
                        driverFuel += track[j];
                    }
                    else
                    {
                        driverFuel -= track[j];
                    }
                    distanceReached = j;
                }
                if (driverFuel > 0)
                {
                    Console.WriteLine($"{drivers[i]} - fuel left {driverFuel:F2}");
                }
                else
                {
                    Console.WriteLine($"{drivers[i]} - reached {distanceReached}");
                }
            }
        }
    }
}
