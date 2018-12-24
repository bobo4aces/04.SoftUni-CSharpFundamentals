using System;
using System.Linq;

namespace _02._Collection
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] commands = Console.ReadLine()
                                    .Split(" ")
                                    .ToArray();

            ListyIterator<string> listyIterator = null;

            while (commands[0]?.ToLower() != "end")
            {
                string command = commands[0]?.ToLower();

                switch (command)
                {
                    case "create":
                        string[] values = commands.Skip(1).ToArray();
                        listyIterator = new ListyIterator<string>(values);
                        break;
                    case "move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "hasnext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                    case "printall":
                        try
                        {
                            foreach (var item in listyIterator)
                            {
                                Console.Write(item + " ");
                            }
                            Console.WriteLine();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                }

                commands = Console.ReadLine()
                .Split(" ")
                .ToArray();
            }
        }
    }
}
