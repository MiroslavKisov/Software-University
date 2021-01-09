using System;
using System.Linq;

namespace KnightsOfHonor
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Action<string> appendSir = message => Console.WriteLine("Sir " + message);
            for (int i = 0; i < names.Length; i++)
            {
                appendSir(names[i]);
            }
        }
    }
}
