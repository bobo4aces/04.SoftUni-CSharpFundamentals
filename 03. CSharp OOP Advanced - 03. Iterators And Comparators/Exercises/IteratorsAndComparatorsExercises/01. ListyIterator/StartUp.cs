using System;
using System.Linq;

namespace _01._ListyIterator
{
    public class StartUp
    {
        public static void Main()
        {
            string[] commands = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] values = commands.Skip(1).ToArray();
            ListyIterator<string> listyIterator = new ListyIterator<string>(values);

            commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (commands[0]?.ToLower() != "end")
            {
                string command = commands.Take(1).Select(c=>c.ToLower()).First();
                switch (command)
                {
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
                    default:
                        throw new InvalidOperationException("Invalid command!");
                }

                commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
        }
    }
}
