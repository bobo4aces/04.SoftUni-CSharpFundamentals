using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _05.Problem_5
{
    class StartUp
    {
        static List<string> paths;

        static void Main(string[] args)
        {
            paths = new List<string>();

            string sourceFile = @"C:\Users\Bo\Desktop\SoftUni\C Sharp Fundamentals\C Sharp Advanced\04. Streams\Homeworks\1\Streams\files\sliceMe.mp4";
            string destionation = @"C:\Users\Bo\Desktop\SoftUni\C Sharp Fundamentals\C Sharp Advanced\04. Streams\Homeworks\1\Streams\files\";
            string assembleDest = @"C:\Users\Bo\Desktop\SoftUni\C Sharp Fundamentals\C Sharp Advanced\04. Streams\Homeworks\1\Streams\files\assemble.mp4";
            int parts = 4;

            Slice(sourceFile, destionation, parts);
            Assemble(paths, assembleDest);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream readFile = new FileStream(sourceFile, FileMode.Open))
            {
                long size = readFile.Length / parts + readFile.Length % parts;

                byte[] buffer = new byte[size];

                for (int i = 0; i < parts; i++)
                {
                    string destinationPath = destinationDirectory + $"Path{i + 1}.mp4";

                    paths.Add(destinationPath);

                    long readedBytes = 0;

                    using (FileStream writeFile = new FileStream(destinationPath, FileMode.Create))
                    {
                        int bytesCount = readFile.Read(buffer, 0, buffer.Length);
                        writeFile.Write(buffer, 0, buffer.Length);
                    }

                    using (GZipStream gz = new GZipStream(new FileStream(destinationPath + ".gz", FileMode.Create), CompressionMode.Compress, false))
                    {
                        gz.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            byte[] buffer = new byte[1024];

            using (FileStream writeFile = new FileStream(destinationDirectory, FileMode.Create))
            {
                foreach (var item in files)
                {
                    using (GZipStream readFile = new GZipStream(new FileStream(item + ".gz" , FileMode.Open), CompressionMode.Decompress))
                    {
                        while (true)
                        {
                            int readedBytes = readFile.Read(buffer, 0, buffer.Length);

                            if (readedBytes == 0)
                            {
                                break;
                            }

                            writeFile.Write(buffer, 0, readedBytes);
                        }
                    }
                }
            }
        }
    }
}
