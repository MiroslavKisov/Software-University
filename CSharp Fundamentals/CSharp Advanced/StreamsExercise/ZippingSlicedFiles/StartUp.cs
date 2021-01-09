using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace SlicingFile
{
    public class StartUp
    {
        private const int bufferSize = 4096;
        public static void Main()
        {
            string sourceFile = "../Resources/sliceMe.mp4";
            string destination = "";
            int parts = 5;
            Zip(sourceFile, destination, parts);
        }
        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);
                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;
                    destinationDirectory = destinationDirectory == string.Empty ?
                        "./" : destinationDirectory;
                    string currentPart = destinationDirectory + $"Part-{i}.{extension}";
                    using (FileStream writer = new FileStream(currentPart, FileMode.Create))
                    {
                        byte[] buffer = new byte[bufferSize];
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPieceSize += bufferSize;
                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        static void Zip(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);
                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;
                    destinationDirectory = destinationDirectory == string.Empty ?
                        "./" : destinationDirectory;
                    string currentPart = destinationDirectory + $"Part-{i}.{extension}.gz";

                    using (GZipStream writer = new GZipStream(new FileStream(currentPart, FileMode.Create)
                        ,CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[bufferSize];
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPieceSize += bufferSize;
                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
