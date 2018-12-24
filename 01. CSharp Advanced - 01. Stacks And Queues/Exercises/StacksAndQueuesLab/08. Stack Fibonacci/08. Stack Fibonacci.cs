using System;
using System.Collections.Generic;

namespace _08._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long count = long.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);
            if (count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            for (long i = 1; i < count; i++)
            {
                long f1 = stack.Pop();
                long f0 = stack.Pop();
                stack.Push(f1);
                f1 = f0 + f1;
                stack.Push(f1);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
