using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _02.Convert_FromBaseNToBase10
{
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            ulong basse = ulong.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);

            BigInteger result = 0;
            char[] numberSplitted = input[1].ToCharArray();
            Array.Reverse(numberSplitted);
            for (int i = 0; i < numberSplitted.Length; i++)
            {
                result += (BigInteger)Char.GetNumericValue(numberSplitted[i]) * BigInteger.Pow(basse, i);
            }
            Console.WriteLine(result);
        }
    }
}
