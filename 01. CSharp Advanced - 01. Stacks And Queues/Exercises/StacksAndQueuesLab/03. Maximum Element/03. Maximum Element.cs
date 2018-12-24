using System;
using System.Collections.Generic;

namespace _03._Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input == "2" && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (input == "3")
                {
                    //If stack is empty?
                    int maxNumber = int.MinValue;
                    foreach (var number in stack)
                    {
                        int currentNumber = int.Parse(number);
                        if (currentNumber > maxNumber)
                        {
                            maxNumber = currentNumber;
                        }
                    }
                    Console.WriteLine(maxNumber);
                }
                else
                {
                    stack.Push(input.Substring(2));
                }
            }
        }
    }
}
