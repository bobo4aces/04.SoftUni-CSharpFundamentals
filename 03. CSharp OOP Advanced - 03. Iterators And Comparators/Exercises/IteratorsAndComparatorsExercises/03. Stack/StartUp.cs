using System;
using System.Linq;

namespace _03._Stack
{
    public class StartUp
    {
        public static void Main()
        {
            string[] inputArgs = Console.ReadLine()
                .Split(new char[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Stack<string> stack = new Stack<string>();

            while (inputArgs[0]?.ToLower() != "end")
            {
                string command = inputArgs[0]?.ToLower();
                switch (command)
                {
                    case "push":
                        stack.Push(inputArgs.Skip(1).ToArray());
                        break;
                    case "pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                }

                inputArgs = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
