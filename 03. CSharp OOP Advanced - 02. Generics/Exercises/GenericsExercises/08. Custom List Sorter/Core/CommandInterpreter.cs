using _08._Custom_List_Sorter;
using _08._Custom_List_Sorter.Entities;
using System;

namespace _08._Custom_List_Sorter.Core
{
    public class CommandInterpreter
    {
        private CustomList<string> customList;

        public CommandInterpreter()
        {
            this.customList = new CustomList<string>();
        }

        public void ModifyCustomList(string[] inputArgs)
        {
            string command = inputArgs[0].ToLower();
            string element = string.Empty;
            uint index = 0;
            switch (command)
            {
                case "add":
                    element = inputArgs[1];
                    customList.Add(element);
                    break;
                case "remove":
                    index = uint.Parse(inputArgs[1]);
                    customList.Remove(index);
                    break;
                case "contains":
                    element = inputArgs[1];
                    bool isContains = customList.Contains(element);
                    Console.WriteLine(isContains);
                    break;
                case "swap":
                    uint firstIndex = uint.Parse(inputArgs[1]);
                    uint secondIndex = uint.Parse(inputArgs[2]);
                    customList.Swap(firstIndex,secondIndex);
                    break;
                case "greater":
                    element = inputArgs[1];
                    uint count = customList.CountGreaterThan(element);
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
                case "sort":
                    Sorter.Sort(customList);
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
