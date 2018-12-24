using _08._Custom_List_Sorter.Core;
using System;
using System.Linq;

namespace _08._Custom_List_Sorter.Core
{
    public class Engine
    {
        private CommandInterpreter commandInterpreter;
        public Engine()
        {
            commandInterpreter = new CommandInterpreter();
        }
        public void Run()
        {
            string[] inputArgs = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (inputArgs[0]?.ToLower() != "end")
            {
                commandInterpreter.ModifyCustomList(inputArgs);

                inputArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
        }
    }
}
