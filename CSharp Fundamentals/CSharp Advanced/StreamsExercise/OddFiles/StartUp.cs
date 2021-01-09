using System;
using System.IO;

namespace OddFiles
{
    public class StartUp
    {
        public static void Main()
        {
            using (var readStream = new StreamReader("text.txt"))
            {
                using (var writeStream = new StreamWriter("output.txt"))
                {
                    string line;
                    int counter = 0;
                    while ((line = readStream.ReadLine()) != null)
                    {
                        if (counter % 2 != 0)
                        {
                            Console.WriteLine(line);
                        }
                        counter++;
                    }
                }
            }
        }
    }
}
