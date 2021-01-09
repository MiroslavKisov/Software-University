using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseString
{
    public class StartUp
    {
        public static void Main()
        {
            string str = Console.ReadLine();
            char[] reversed = new char[str.Length];
            reversed = str.ToCharArray();
            Array.Reverse(reversed);
            Console.WriteLine(new string(reversed));
        }
    }
}
