namespace SliceFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private const string destinationPath = @"..\..\..\SlicedVideoFiles\";
        private const string sourceFilePath = @"..\..\..\VideoFiles\";
        private const string assembledFilesPath = @"..\..\..\AssembledFiles\";
        private const int bufferSize = 4096;

        public void Run()
        {
            var sourceFile = sourceFilePath + Console.ReadLine();
            var parts = int.Parse(Console.ReadLine());

            var directoryInfo = new DirectoryInfo(destinationPath);
            var filesNames = directoryInfo.GetFiles().Select(e => e.Name).ToList();

            SliceAsync(sourceFile, destinationPath, parts);
            Console.WriteLine("Anything else?");

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
            }
        }

        private void AssembleAsync(List<string> filesNames, string assembledFilesPath)
        {
            Task.Run(() =>
            {
                Assemble(filesNames, assembledFilesPath);
            });
        }

        private void SliceAsync(string sourceFile, string destinationPath, int parts)
        {
            Task.Run(() => 
            {
                Slice(sourceFile, destinationPath, parts);
            });
        }

        private void Slice(string sourceFile, string destinationPath, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);
                string fileExtension = new FileInfo(sourceFile).Extension;
                string fileName = new FileInfo(sourceFile).Name;

                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                for (int i = 0; i < parts; i++)
                {
                    string partName = destinationPath + $"Part-{i} {fileName}";
                    long currentPieceSize = 0;

                    using (FileStream writer = new FileStream(partName, FileMode.Create))
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

            Console.WriteLine("Slice complete");
        }

        private void Assemble(List<string> files, string assebledFilesPath)
        {
            string fileExtension = new FileInfo(files[0]).Extension;

            if (!Directory.Exists(assebledFilesPath))
            {
                Directory.CreateDirectory(assebledFilesPath);
            }

            string assembledFileName = $"{assebledFilesPath}Assembled{fileExtension}";

            using (FileStream writer = new FileStream(assembledFileName, FileMode.Create))
            {
                byte[] buffer = new byte[bufferSize];

                foreach (var file in files)
                {
                    using (var reader = new FileStream(destinationPath + file, FileMode.Open))
                    {
                        int size = reader.Read(buffer, 0, bufferSize);

                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }

            Console.WriteLine("Assemble complete");
        }
    }
}
