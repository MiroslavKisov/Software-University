using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CharacterMultiplier
{
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray(); ;
            string firstString = input[0];
            string secondString = input[1];
            int sum = SumOfSymbols(firstString, secondString);
            Console.WriteLine(sum);
        }

        private static int SumOfSymbols(string firstString, string secondString)
        {
            int sum = 0;
            if (firstString.Length > secondString.Length)
            {
                int diff = firstString.Length - secondString.Length;
                string temp = firstString.Substring(secondString.Length, diff);
                for (int i = 0; i < secondString.Length; i++)
                {
                    sum += firstString[i] * secondString[i];
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    sum += temp[i];
                }
                return sum;
            }
            else if (firstString.Length < secondString.Length)
            {
                int diff = secondString.Length - firstString.Length;
                string temp = secondString.Substring(firstString.Length, diff);
                for (int i = 0; i < firstString.Length; i++)
                {
                    sum += firstString[i] * secondString[i];
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    sum += temp[i];
                }
                return sum;
            }
            else
            {
                for (int i = 0; i < firstString.Length; i++)
                {
                    sum += firstString[i] * secondString[i];
                }
                return sum;
            }
        }  
    }
}
