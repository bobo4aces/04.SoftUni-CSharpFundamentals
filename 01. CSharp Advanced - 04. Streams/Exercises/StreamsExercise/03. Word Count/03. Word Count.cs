using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../../../";
            string wordsFileName = "words.txt";
            string textFileName = "text.txt";
            string resultFileName = "result.txt";

            //01. Creating the file "words.txt" and writing words to it.

            string wordsFile = Path.Combine(path, wordsFileName);
            FileStream fileStream = new FileStream(wordsFile, FileMode.Create);

            try
            {
                string[] inputWords = new string[] { "quick", "is", "fault" };
                foreach (var word in inputWords)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(word + Environment.NewLine);
                    fileStream.Write(bytes, 0, bytes.Length);
                }
            }
            finally
            {
                fileStream.Close();
            }

            //02. Reading from file "words.txt" and adding the words to the hashset

            HashSet<string> words = new HashSet<string>();
            StreamReader wordsReader = new StreamReader(wordsFile);

            using (wordsReader)
            {
                string line = wordsReader.ReadLine();

                while (line != null)
                {
                    List<string> currentWords = SplitWords(line);

                    foreach (var currentWord in currentWords)
                    {
                        words.Add(currentWord);
                    }

                    line = wordsReader.ReadLine();
                }
            }

            //03. Reading from file "text.txt" and filling the dictionary with the words and their count

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            string textFile = Path.Combine(path, textFileName);
            StreamReader textReader = new StreamReader(textFile);

            using (textReader)
            {
                string line = textReader.ReadLine();
                while (line != null)
                {
                    List<string> currentWords = SplitWords(line);
                    foreach (var currentWord in currentWords)
                    {
                        if (words.Contains(currentWord))
                        {
                            if (!wordsCount.ContainsKey(currentWord))
                            {
                                wordsCount.Add(currentWord, 0);
                            }
                            wordsCount[currentWord]++;
                        }
                    }
                    line = textReader.ReadLine();
                } 
            }

            //04. Creating file "result.txt" and writing the words and their count from the dictionary
            string resultFile = Path.Combine(path, resultFileName);
            FileStream resultFileStream = new FileStream(resultFile, FileMode.Create);
            try
            {
                foreach (var word in wordsCount.OrderByDescending(w => w.Value))
                {
                    string output = $"{word.Key} - {word.Value}";
                    byte[] bytes = Encoding.UTF8.GetBytes(output + Environment.NewLine);
                    resultFileStream.Write(bytes, 0, bytes.Length);
                }
            }
            finally
            {
                resultFileStream.Close();
            }
        }

        public static List<string> SplitWords(string text)
        {
            List<string> words = new List<string>();
            StringBuilder currentWord = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    currentWord.Append(text[i]);
                }
                else
                {
                    words.Add(currentWord.ToString().ToLower());
                    currentWord.Clear();
                }
            }
            words.Add(currentWord.ToString().ToLower());
            currentWord.Clear();
            return words;
        }
    }
}
