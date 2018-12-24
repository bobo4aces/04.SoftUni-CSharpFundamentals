using System;
using System.IO;

namespace _04.Problem_4
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string sourceFile = @"C:\Users\Bo\Desktop\SoftUni\C Sharp Fundamentals\C Sharp Advanced\04. Streams\Homeworks\1\Streams\files\copyMe.png";
            string destinationPath = @"C:\Users\Bo\Desktop\SoftUni\C Sharp Fundamentals\C Sharp Advanced\04. Streams\Homeworks\1\Streams\files\copyMe-copy.png";

            using (FileStream readFile = new FileStream(sourceFile, FileMode.Open))
            {
                var size = readFile.Length;

                byte[] buffer = new byte[size];

                readFile.Read(buffer, 0, buffer.Length);

                using (FileStream writeFile = new FileStream(destinationPath, FileMode.Create))
                {
                    writeFile.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
