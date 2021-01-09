using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.RageQuit
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine().ToUpper();
            List<char> inputSymbols = input.ToCharArray().ToList();
            List<char> resultSymbols = new List<char>();
            StringBuilder finalString = new StringBuilder();
            StringBuilder printString = new StringBuilder();
            int printNumberOfTimes = 0;
            int distinctCounter = 0;
            string distinctString = string.Empty;
            string nums = string.Empty;
            bool isDigit = false;
            for (int i = 0; i < inputSymbols.Count; i++)
            {
                if (Char.IsLetter(inputSymbols[i]) 
                    || Char.IsSymbol(inputSymbols[i]) 
                    || Char.IsPunctuation(inputSymbols[i])
                    || Char.IsWhiteSpace(inputSymbols[i])
                    || Char.IsSeparator(inputSymbols[i])
                    || Char.IsControl(inputSymbols[i]))
                {
                    if (isDigit)
                    {
                        AppendCurrentString(printString, printNumberOfTimes,finalString);
                        printString.Clear();
                        nums = string.Empty;
                        isDigit = false;
                    }
                    printString.Append(inputSymbols[i]);
                }

                else if (Char.IsNumber(inputSymbols[i]))
                {
                    isDigit = true;
                    nums += inputSymbols[i];
                    printNumberOfTimes = int.Parse(nums);
                    if (i == inputSymbols.Count - 1)
                    {
                        AppendCurrentString(printString, printNumberOfTimes, finalString);
                    }
                }
            }

            distinctString = finalString.ToString();
            distinctCounter = distinctString.Distinct().Count();
            Console.WriteLine($"Unique symbols used: {distinctCounter}");
            Console.WriteLine($"{finalString}");
        }

        private static void AppendCurrentString(StringBuilder printString, int printNumberOfTimes, StringBuilder finalString)
        {
            for (int i = 0; i < printNumberOfTimes; i++)
            {
                finalString.Append(printString);
            }
        }
    }
}
