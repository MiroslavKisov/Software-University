using System;
using System.Numerics;

namespace _01.CharityMarathon
{
    public class StartUp
    {
        public static void Main()
        {
            BigInteger daysOfMarathon = BigInteger.Parse(Console.ReadLine());
            BigInteger numberOfRunners = BigInteger.Parse(Console.ReadLine());
            BigInteger numberOfLaps = BigInteger.Parse(Console.ReadLine());
            BigInteger lengthOfTrack = BigInteger.Parse(Console.ReadLine());
            BigInteger trackCapacity = BigInteger.Parse(Console.ReadLine());
            double moneyDonatedPerKilometer = double.Parse(Console.ReadLine());
            if (daysOfMarathon * trackCapacity < numberOfRunners)
            {
                numberOfRunners = daysOfMarathon * trackCapacity;
            }
            BigInteger totalMeters = numberOfRunners * numberOfLaps * lengthOfTrack;
            double totalKilometers = (double)(totalMeters / 1000);
            decimal totalMoney = (decimal)(totalKilometers * moneyDonatedPerKilometer);
            Console.WriteLine($"Money raised: {totalMoney:F2}");
        }
    }
}
