using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operationsCount = int.Parse(Console.ReadLine());
            string text = string.Empty;
            Stack<string> undoes = new Stack<string>();
            for (int i = 0; i < operationsCount; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                switch (command[0])
                {
                    case "1":
                        undoes.Push(text);
                        text += command[1];
                        break;
                    case "2":
                        undoes.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(command[1]));
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(command[1]) - 1]);
                        break;
                    case "4":
                        text = undoes.Pop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
