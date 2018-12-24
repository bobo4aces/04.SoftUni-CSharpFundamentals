using System;
using System.Linq;

namespace _06._Jagged_Arr_Modify
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            while (command[0]?.ToLower() != "end")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(0))
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (command[0].ToLower() == "add")
                {
                    matrix[row][col] += value;
                }
                else if (command[0].ToLower() == "subtract")
                {
                    matrix[row][col] -= value;
                }

                command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            }

            foreach (var elements in matrix)
            {
                Console.WriteLine(String.Join(" ",elements));
            }
        }
    }
}
