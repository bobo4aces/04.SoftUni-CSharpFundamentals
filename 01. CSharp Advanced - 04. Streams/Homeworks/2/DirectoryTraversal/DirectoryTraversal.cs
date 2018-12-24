using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace ExerciseStreams
{
    public class DirectoryTraversal
    {
        static string targetFolder = "@../../../../../../Files/";
        static Dictionary<string, Dictionary<string, long>> fileDictionary = new Dictionary<string, Dictionary<string, long>>();

        public static void Main()
        {
            GetFilesFromDirectory();

            SaveFiles();
        }

        private static void SaveFiles()
        {
            using (var writer = new StreamWriter($"{targetFolder}report.txt"))
            {
                foreach (var group in fileDictionary.OrderByDescending(g => g.Value.Count).ThenBy(g => g.Key))
                {
                    var filesInGroup = string.Join(Environment.NewLine,
                         group.Value
                        .OrderByDescending(v => v.Value)
                        .Select(kvp => $"--{kvp.Key} - {kvp.Value}kb"));

                    writer.Write($"{group.Key}{Environment.NewLine}{filesInGroup}{Environment.NewLine}");
                }
            }
        }

        private static void GetFilesFromDirectory()
        {
            var files = Directory.GetFiles(targetFolder);

            foreach (var file in files)
            {
                var extension = Path.GetExtension(file);
                var fileSize = new FileInfo(file).Length;

                if (!fileDictionary.ContainsKey(extension)) fileDictionary[extension] = new Dictionary<string, long>();
                fileDictionary[extension].Add(file, fileSize);
            }
        }
    }
}
