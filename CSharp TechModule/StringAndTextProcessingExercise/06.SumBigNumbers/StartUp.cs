using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _06.SumBigNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
            BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());
            BigInteger sum = firstNumber + secondNumber;
            Console.WriteLine(sum);
        }
    }
}
