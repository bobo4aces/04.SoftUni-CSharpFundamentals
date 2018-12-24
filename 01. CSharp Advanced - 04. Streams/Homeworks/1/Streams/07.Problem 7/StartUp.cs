using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.Problem_7
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, decimal>> info = new Dictionary<string, Dictionary<string, decimal>>();

            string[] files = Directory.GetFiles(@"C:\Users\Bo\Desktop\SoftUni\C Sharp Fundamentals\C Sharp Advanced\04. Streams\Homeworks\1\Streams\files\", " *.*", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                var currentFile = File.Open(file, FileMode.Open);

                var fullName = Path.GetFileName(file);
                var extension = Path.GetExtension(file);
                Decimal fileSize = Decimal.Divide(currentFile.Length, 1024);
                
                if(info.ContainsKey(extension) == false)
                {
                    info.Add(extension, new Dictionary<string, decimal>());
                }

                if(info[extension].ContainsKey(fullName) == false)
                {
                    info[extension].Add(fullName, fileSize);
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\report.txt";

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var current in info.OrderByDescending(x => x.Value.Count).ThenBy(k => k.Key))
                {
                    writer.WriteLine(current.Key);

                    foreach (var fileInfo in current.Value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"--{fileInfo.Key} - {fileInfo.Value:f2}kb.");
                    }
                }
            }
        }
    }
}
