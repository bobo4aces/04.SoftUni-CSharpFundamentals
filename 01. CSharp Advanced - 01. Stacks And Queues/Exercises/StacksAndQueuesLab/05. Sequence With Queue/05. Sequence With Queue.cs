using System;
using System.Collections.Generic;

namespace _05._Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[] array = { n};
            Queue<long> queue = new Queue<long>(array);
            for (long i = 0; i < 50; i++)
            {
                queue.Enqueue(n + 1);
                queue.Enqueue(2 * n + 1);
                queue.Enqueue(n + 2);
                Console.Write(queue.Dequeue() +" ");
                n = queue.Peek();
            }
            Console.WriteLine();
        }
    }
}
