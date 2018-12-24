using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] matrix = new int[rows][];


            GetMatrix(matrix, cols);
            
            
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int position = int.Parse(command[0]);
                string direction = command[1].ToLower();
                int moves = int.Parse(command[2]);

                if (direction == "up")
                {
                    MoveUp(matrix, position, moves % matrix.Length);
                }
                else if (direction == "down")
                {
                    MoveDown(matrix, position, moves % matrix.Length);
                }
                else if (direction == "left")
                {
                    MoveLeft(matrix, position, moves % matrix.Length);
                }
                else if (direction == "right")
                {
                    MoveRight(matrix, position, moves % matrix.Length);
                }
            }

            int counter = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == counter)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        Rearrange(matrix, row, col, counter);
                        
                    }
                    counter++;
                }
            }
        }

        private static void GetMatrix(int[][] matrix, int cols)
        {
            int counter = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[cols];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = counter++;
                }
            }
        }

        private static void Rearrange(int[][] matrix, int row, int col, int counter)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == counter)
                    {
                        matrix[i][j] = matrix[row][col];
                        matrix[row][col] = counter;
                        Console.WriteLine($"Swap ({row}, {col}) with ({i}, {j})");
                        return;
                    }
                }
            }
        }

        private static void MoveRight(int[][] matrix, int position, int moves)
        {
            while (moves != 0)
            {
                int lastColIndex = matrix.Length - 1;
                int lastNumber = matrix[position][lastColIndex];
                for (int j = matrix.Length - 1; j > 0; j--)
                {
                    matrix[position][j] = matrix[position][j - 1];
                }
                matrix[position][0] = lastNumber;
                moves--;
            }
        }

        private static void MoveLeft(int[][] matrix, int position, int moves)
        {
            while (moves != 0)
            {
                int firstNumber = matrix[position][0];
                for (int j = 0; j < matrix.Length - 1; j++)
                {
                    matrix[position][j] = matrix[position][j + 1];
                }
                int lastColIndex = matrix.Length - 1;
                matrix[position][lastColIndex] = firstNumber;
                moves--;
            }
        }

        private static void MoveDown(int[][] matrix, int position, int moves)
        {
            while (moves != 0)
            {
                int lastRowIndex = matrix.Length - 1;
                int lowerNumber = matrix[lastRowIndex][position];
                for (int j = matrix.Length - 1; j > 0; j--)
                {
                    matrix[j][position] = matrix[j - 1][position];
                }
                matrix[0][position] = lowerNumber;
                moves--;
            }
        }

        private static void MoveUp(int[][] matrix, int position, int moves)
        {
            while (moves != 0)
            {
                int upperNumber = matrix[0][position];
                for (int j = 0; j < matrix.Length - 1; j++)
                {
                    matrix[j][position] = matrix[j + 1][position];
                }
                int lastRowIndex = matrix.Length - 1;
                matrix[lastRowIndex][position] = upperNumber;
                moves--;
            }
        }
    }
}
