using System.IO;

namespace ExerciseStreams
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream(@"../../../../Files/copyMe.png", FileMode.Open))
            {
                byte[] buffer = new byte[4096];

                using (FileStream writer = new FileStream(@"../../../../Files/result.png", FileMode.Create))
                {
                    while (true)
                    {
                        var bytesCount = reader.Read(buffer, 0, buffer.Length);
                        if (bytesCount == 0) break;
                        writer.Write(buffer, 0, bytesCount);
                    }
                }
            }
        }
    }
}
