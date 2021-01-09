using System;
using System.Linq;
using System.Numerics;

namespace _01.SinoTheWalker
{
    public class StartUp
    {
        public static void Main()
        {
            string inputTime = Console.ReadLine();
            BigInteger stepsNeeded = BigInteger.Parse(Console.ReadLine());
            BigInteger timePerStep = BigInteger.Parse(Console.ReadLine());
            var startTime = inputTime.Split(':').ToArray();
            BigInteger totalTimeInSeconds
                = BigInteger.Parse(startTime[0]) * 3600
                + BigInteger.Parse(startTime[1]) * 60
                + BigInteger.Parse(startTime[2]);
            BigInteger timeToGetHome = timePerStep * stepsNeeded;
            totalTimeInSeconds += timeToGetHome;
            BigInteger hours = (totalTimeInSeconds / 3600) % 24; 
            BigInteger minutes = (totalTimeInSeconds % 3600) / 60;
            BigInteger seconds = (totalTimeInSeconds % 3600) % 60;
            if (seconds > 59)
            {
                minutes++;
                seconds = 0;
            }
            if (minutes > 59)
            {
                hours++;
                minutes = 0;
            }
            if (hours > 23)
            {
                hours = hours - 24;
            }
            Console.WriteLine($"Time Arrival: {hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }
}