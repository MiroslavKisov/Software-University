using System;
using System.Linq;

namespace ActionPrint
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Action<string> printMsg = message => Console.WriteLine(message);
            for (int i = 0; i < input.Length; i++)
            {
                printMsg(input[i]);
            }
        } 
    }
}
