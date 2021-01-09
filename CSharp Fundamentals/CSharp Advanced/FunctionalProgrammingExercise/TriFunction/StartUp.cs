using System;
using System.Linq;

namespace TriFunction
{
    public class StartUp
    {
        public static void Main()
        {
            int nameNumber = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < names.Length; i++)
            {
                int nameSum = 0;
                var currentName = names[i].ToCharArray();
                for (int j = 0; j < currentName.Length; j++)
                {
                    nameSum += currentName[j];
                    if (nameSum >= nameNumber)
                    {
                        Console.WriteLine(names[i]);
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
