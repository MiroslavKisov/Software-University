using System;
using System.Linq;

namespace PredicateForNames
{
    public class Program
    {
        public static void Main()
        {
            int nameLenght = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Func<string, bool> filter = n => n.Length <= nameLenght;
            names = names.Where(filter).ToArray();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
