using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Solve the task correctly when u have the time...
namespace RecursiveFibonacci
{
    public class StartUp
    {
        public static void Main()
        {
            long firstFibo = 1;
            long secondFibo = 1;
            long currentFibo = 0;
            long nthFibo = long.Parse(Console.ReadLine());
            for (int i = 0; i < nthFibo - 2; i++)
            {
                currentFibo = firstFibo + secondFibo;
                firstFibo = secondFibo;
                secondFibo = currentFibo;
            }
            if (nthFibo == 1 || nthFibo == 2)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(currentFibo);
            }
        }
    }
}
