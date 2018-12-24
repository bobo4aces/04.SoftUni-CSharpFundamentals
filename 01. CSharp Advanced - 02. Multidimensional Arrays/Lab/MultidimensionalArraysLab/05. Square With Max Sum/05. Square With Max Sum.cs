using System;
using System.Linq;

namespace _05._Square_With_Max_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int maxSum = int.MinValue;
            int row = 0;
            int col = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int sum = 0;
                    sum += matrix[i, j] + matrix[i, j + 1];
                    sum += matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        row = i;
                        col = j;
                    }
                }
            }

            for (int i = row; i < row + 2; i++)
            {
                for (int j = col; j < col + 2; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
