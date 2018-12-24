using _07._Custom_List.Contracts;
using _07._Custom_List.Entities;
using System;

namespace _07._Custom_List.Core
{
    public class CommandInterpreter
    {
        private ICustomList<string> customList;

        public CommandInterpreter()
        {
            this.customList = new CustomList<string>();
        }

        public void ModifyCustomList(string[] inputArgs)
        {
            string command = inputArgs[0].ToLower();
            string element = string.Empty;
            int index = 0;
            switch (command)
            {
                case "add":
                    element = inputArgs[1];
                    customList.Add(element);
                    break;
                case "remove":
                    index = int.Parse(inputArgs[1]);
                    customList.Remove(index);
                    break;
                case "contains":
                    element = inputArgs[1];
                    bool isContains = customList.Contains(element);
                    Console.WriteLine(isContains);
                    break;
                case "swap":
                    int firstIndex = int.Parse(inputArgs[1]);
                    int secondIndex = int.Parse(inputArgs[2]);
                    customList.Swap(firstIndex,secondIndex);
                    break;
                case "greater":
                    element = inputArgs[1];
                    int count = customList.CountGreaterThan(element);
                    Console.WriteLine(count);
                    break;
                case "max":
                    string maxElement = customList.Max();
                    Console.WriteLine(maxElement);
                    break;
                case "min":
                    string minElement = customList.Min();
                    Console.WriteLine(minElement);
                    break;
                case "print":
                    Console.WriteLine(customList);
                    break;
                default:
                    throw new InvalidOperationException("Invalid command!");
            }
        }
    }
}
