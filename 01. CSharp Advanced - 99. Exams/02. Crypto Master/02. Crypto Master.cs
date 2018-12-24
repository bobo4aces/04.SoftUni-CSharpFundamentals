using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Crypto_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            int[] counts = new int[numbers.Length];
            Stack<int> indexes = new Stack<int>();
            indexes.Push(0);

            for (int i = 1; i < numbers.Length; i++)
            {
                int maxLength = 0;
                while (queue.Count() > 0 || numbers[indexes.Peek()] >= numbers[i])
                {

                }
            }
            while (queue.Count > 0 || counter != numbers.Length)
            {
                int currentNumber = queue.Dequeue();
                if (currentNumber < queue.Peek())
                {
                    length++;
                }
                else
                {
                    if (length > maxLength)
                    {
                        maxLength = length;
                    }
                    length = 0;
                }
                queue.Enqueue(currentNumber);
                counter++;
            }
            Console.WriteLine(maxLength);
        }
    }
}
