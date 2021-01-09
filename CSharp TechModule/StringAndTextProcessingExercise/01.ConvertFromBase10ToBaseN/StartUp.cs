using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.ConvertFromBase10ToBaseN
{
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            BigInteger baseToConvert = BigInteger.Parse(input[0]);
            BigInteger tenBasedNumber = BigInteger.Parse(input[1]);
            BigInteger temp = 0;
            string result = string.Empty;

            while (tenBasedNumber > 0)
            {
                temp = tenBasedNumber % baseToConvert;
                result += temp.ToString();
                tenBasedNumber = tenBasedNumber / baseToConvert;
            }

            char[] resultChar = result.ToCharArray();
            Array.Reverse(resultChar);
            string converted = new string(resultChar);
            Console.WriteLine(converted);
        }
    }
}
