using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Task01
{
    class Task01
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long dataTransfer = 0;
            for (int i = 0; i < n; i++)
            {
                string[] text = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (text.Length != 3)
                {
                    continue;
                }
                if (!text[0].StartsWith("s:"))
                {
                    continue;
                }
                if (!text[1].StartsWith("r:"))
                {
                    continue;
                }
                if (!text[2].StartsWith("m--"))
                {
                    continue;
                }
                string sender = text[0].Substring(2);
                string receiver = text[1].Substring(2);
                string message = text[2].Substring(4);
                message = string.Join("",message.SkipLast(1));
                //Console.WriteLine(message);
                if (!Regex.IsMatch(message, "^[A-Za-z ]+$"))
                {
                    continue;
                }

                string senderName = String.Empty;
                string receiverName = String.Empty;
                for (int j = 0; j < sender.Length; j++)
                {
                    if (Char.IsDigit(sender[j]))
                    {
                        dataTransfer += long.Parse(sender[j].ToString());
                    }
                    if (Char.IsLetter(sender[j]) || sender[j] == ' ')
                    {
                        senderName += sender[j];
                    }
                }
                for (int j = 0; j < receiver.Length; j++)
                {
                    if (Char.IsDigit(receiver[j]))
                    {
                        dataTransfer += long.Parse(receiver[j].ToString());
                    }
                    if (Char.IsLetter(receiver[j]) || receiver[j] == ' ')
                    {
                        receiverName += receiver[j];
                    }
                }
                Console.WriteLine($"{senderName} says \"{message}\" to {receiverName}");
            }
            Console.WriteLine($"Total data transferred: {dataTransfer}MB");
        }
    }
}
