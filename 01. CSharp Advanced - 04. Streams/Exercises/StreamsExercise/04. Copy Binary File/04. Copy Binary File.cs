using System;
using System.IO;

namespace _04._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../../../";
            string fileName = "copyMe.png";
            string copiedfileName = "copyMe(1).png";

            string file = Path.Combine(path, fileName);
            string copiedFile = Path.Combine(path, copiedfileName);

            FileStream source = new FileStream(file, FileMode.Open);

            using (source)
            {
                FileStream destination = new FileStream(copiedFile,FileMode.CreateNew);

                using (destination)
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
            
        }
    }
}
