using System;
using System.IO;

namespace CopyBinaryFile
{
    public class StartUp
    {
        public static void Main()
        {
            using (var sourceFile = new FileStream("copyMe.png", FileMode.Open))
            {
                using (var destinationFile = new FileStream("copyME-copy.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        var readFilesCounter = sourceFile.Read(buffer, 0, buffer.Length);
                        if (readFilesCounter == 0)
                        {
                            break;
                        }
                        destinationFile.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
