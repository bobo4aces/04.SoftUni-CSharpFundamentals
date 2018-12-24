using System;
using System.Linq;

namespace _07._Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[3][];

            matrix[0] = numbers.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            matrix[1] = numbers.Where(n => Math.Abs(n) % 3 == 1).ToArray();
            matrix[2] = numbers.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(String.Join(" ", matrix[i]));
            }
        }
    }
}
