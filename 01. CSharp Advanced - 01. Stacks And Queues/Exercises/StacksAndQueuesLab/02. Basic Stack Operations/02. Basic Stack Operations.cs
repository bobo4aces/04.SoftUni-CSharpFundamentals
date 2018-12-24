using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int pushElementsCount = input[0];
            int popElementsCount = input[1];
            int lookupElement = input[2];

            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < pushElementsCount; i++)
            {
                if (array.Length > i)
                {
                    stack.Push(array[i]);
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < popElementsCount; i++)
            {
                if (array.Length > i)
                {
                    stack.Pop();
                }
                else
                {
                    break;
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(lookupElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                int lowestNumber = int.MaxValue;
                foreach (var number in stack)
                {
                    if (number < lowestNumber)
                    {
                        lowestNumber = number;
                    }
                }
                Console.WriteLine(lowestNumber);
            }
        }
    }
}
