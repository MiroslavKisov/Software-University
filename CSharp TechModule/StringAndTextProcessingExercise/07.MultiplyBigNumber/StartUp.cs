using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _07.MultiplyBigNumber
{
    public class StartUp
    {
        public static void Main()
        {
            BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
            BigInteger secondNUmber = BigInteger.Parse(Console.ReadLine());
            BigInteger result = firstNumber * secondNUmber;
            Console.WriteLine(result);
        }
    }
}
