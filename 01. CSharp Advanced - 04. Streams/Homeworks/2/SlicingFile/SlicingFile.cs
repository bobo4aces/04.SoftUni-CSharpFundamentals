using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ExerciseStreams
{
    class StartUp
    {
        static List<string> paths;

        static void Main(string[] args)
        {
            paths = new List<string>();

            string sourceFile = "..//..//..//..//files//sliceMe.mp4";
            string destionation = "..//..//..//..//files//";
            string assembleDest = "..//..//..//..//files//assemble.mp4";
            int parts = 4;

            Slice(sourceFile, destionation, parts);
            Assemble(paths, assembleDest);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            {
                List<string> listSliced = new List<string>();
                List<string> listZipped = new List<string>();
                int lastBfSize;
                int count = 1;

                count = 1;

                using (FileStream readStream = new FileStream(sourceFile, FileMode.Open))
                {
                    int bufferSize = (int)readStream.Length / parts;
                    var buffer = new byte[bufferSize];

                    while (count <= parts)
                    {
                        listSliced.Add($"{destinationDirectory}Part{count}.mp4");
                        paths.Add($"{destinationDirectory}Part{count}");

                        using (FileStream writeStream = new FileStream($"{destinationDirectory}Part{count}.mp4", FileMode.Create))
                        using (FileStream writeGzStream = new FileStream($"{destinationDirectory}Part{count}.gz", FileMode.Create))
                        {

                            if (count == parts)
                            {
                                lastBfSize = (int)readStream.Length / parts + (int)readStream.Length % parts;
                                buffer = new byte[lastBfSize];
                            }


                            using (GZipStream gzipStream = new GZipStream(writeGzStream, CompressionMode.Compress, false))
                            {
                                var bytes = readStream.Read(buffer, 0, buffer.Length);
                                gzipStream.Write(buffer, 0, bytes);
                                writeStream.Write(buffer, 0, bytes);
                            }
                        }
                        count++;
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
                    using (GZipStream readFile = new GZipStream(new FileStream(item + ".gz", FileMode.Open), CompressionMode.Decompress))
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