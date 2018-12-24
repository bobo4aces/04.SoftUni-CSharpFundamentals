using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int enquequeElements = elements[0];
            int dequequeElements = elements[1];
            int lookupElement = elements[2];

            Queue<int> queque = new Queue<int>();

            for (int i = 0; i < enquequeElements; i++)
            {
                queque.Enqueue(array[i]);
            }

            for (int i = 0; i < dequequeElements; i++)
            {
                queque.Dequeue();
            }
            if (queque.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queque.Contains(lookupElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallestElement = int.MaxValue;

                foreach (var number in queque)
                {
                    if (number < smallestElement)
                    {
                        smallestElement = number;
                    }
                }

                Console.WriteLine(smallestElement);
            }
        }
    }
}
