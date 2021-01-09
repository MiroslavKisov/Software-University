using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.UnicodeCharacters
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            char[] symbols = input.ToCharArray();
            string result = string.Empty;
            for (int i = 0; i < symbols.Length; i++)
            {
                result += "\\u" + ((int)symbols[i]).ToString("x").PadLeft(4, '0');
            }
            Console.WriteLine(result);
        }
    }
}
