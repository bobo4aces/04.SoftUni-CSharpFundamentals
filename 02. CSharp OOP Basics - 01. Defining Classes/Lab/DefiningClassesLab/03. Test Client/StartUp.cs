using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccount
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] commands = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(e => e.ToLower())
                .ToArray();

            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

            while (commands[0] != "end")
            {
                if (commands[0] == "create")
                {
                    BankAccount.Create(commands, accounts);
                }
                else if (commands[0] == "deposit")
                {
                    BankAccount.Deposit(commands, accounts);
                }
                else if (commands[0] == "withdraw")
                {
                    BankAccount.Withdraw(commands, accounts);
                }
                else if (commands[0] == "print")
                {
                    BankAccount.Print(commands, accounts);
                }
                commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(e => e.ToLower())
                .ToArray();
            }
        }
    }
}
