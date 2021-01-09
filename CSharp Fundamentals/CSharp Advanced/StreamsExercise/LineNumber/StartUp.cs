using System;
using System.IO;

namespace LineNumber
{
    public class StartUp
    {
        public static void Main()
        {
            using (var streamReader = new StreamReader("text.txt"))
            {
                using (var streamWriter = new StreamWriter("output.txt"))
                {
                    string line;
                    int lineCounter = 1;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine($"Line {lineCounter++}: {line}");
                    }
                }
            }
        }
    }
}
