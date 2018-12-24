using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _08._Full_Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string[] allFiles = Directory.GetFiles(path);
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            
            foreach (var directory in directoryInfo.Pa)
            {
                Console.WriteLine(directory);
            }
            //Dictionary<string, Dictionary<string, double>> extensionFileSize = new Dictionary<string, Dictionary<string, double>>();
            //
            //foreach (var file in allFiles)
            //{
            //    FileInfo fileInfo = new FileInfo(file);
            //    string extension = fileInfo.Extension;
            //    string name = fileInfo.Name;
            //    double size = fileInfo.Length / 1024 + 1;
            //
            //    if (!extensionFileSize.ContainsKey(extension))
            //    {
            //        extensionFileSize.Add(extension, new Dictionary<string, double>());
            //    }
            //    if (!extensionFileSize[extension].ContainsKey(name))
            //    {
            //        extensionFileSize[extension].Add(name, size);
            //    }
            //}
            //string desktop = $"C:/Users/{Environment.UserName}/Desktop";
            //string fileName = "report.txt";
            //string report = Path.Combine(desktop, fileName);
            //
            //FileStream fileStream = new FileStream(report, FileMode.Create);
            //
            //string output = String.Empty;
            //
            //using (fileStream)
            //{
            //
            //    foreach (var extension in extensionFileSize.OrderByDescending(e => e.Value.Count()).ThenBy(e => e.Key))
            //    {
            //        output += extension.Key + Environment.NewLine;
            //        foreach (var file in extension.Value.OrderBy(s => s.Value))
            //        {
            //            output += $"--{file.Key} - {file.Value}kb" + Environment.NewLine;
            //        }
            //    }
            //
            //    try
            //    {
            //        byte[] bytes = Encoding.UTF8.GetBytes(output);
            //        fileStream.Write(bytes, 0, bytes.Length);
            //    }
            //    finally
            //    {
            //        fileStream.Close();
            //    }
            //}
        }
    }
}
