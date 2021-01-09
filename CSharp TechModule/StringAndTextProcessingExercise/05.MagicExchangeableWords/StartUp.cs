using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.MagicExchangeableWords
{
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();
            AreExchangeable(input[0], input[1]);
        }

        private static void AreExchangeable(string firstWord, string secondWord)
        {
            string distinctFirstLetters = new string (firstWord.Distinct().ToArray());
            string distinctSecondLetters = new string(secondWord.Distinct().ToArray());
            if (distinctFirstLetters.Length == distinctSecondLetters.Length)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
