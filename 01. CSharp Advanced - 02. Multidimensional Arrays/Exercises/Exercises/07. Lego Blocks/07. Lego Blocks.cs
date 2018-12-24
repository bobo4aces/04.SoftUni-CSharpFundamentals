using System;
using System.Linq;

namespace _07._Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            int[][] firstMatrix = new int[rowsCount][];
            int[][] secondMatrix = new int[rowsCount][];

            int firstMatrixTotalCells = 0;
            int secondMatrixTotalCells = 0;

            //Fill first and second matrix and count total cells
            for (int i = 0; i < rowsCount * 2; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (i >= rowsCount)
                {
                    secondMatrix[i - rowsCount] = currentRow;
                    secondMatrixTotalCells += currentRow.Length;
                }
                else
                {
                    firstMatrix[i] = currentRow;
                    firstMatrixTotalCells += currentRow.Length;
                }
            }

            int totalLength = firstMatrix[0].Length + secondMatrix[0].Length;

            for (int i = 1; i < rowsCount; i++)
            {
                if (firstMatrix[i].Length + secondMatrix[i].Length != totalLength)
                {
                    Console.WriteLine($"The total number of cells is: {firstMatrixTotalCells + secondMatrixTotalCells}");
                    return;
                }
            }

            int[,] finalMatrix = new int[rowsCount,totalLength];

            int counter = 0;

            for (int row = 0; row < finalMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < finalMatrix.GetLength(1); col++)
                {
                    if (col >= firstMatrix[row].Length )
                    {
                        int currentElement = secondMatrix[row][secondMatrix[row].Length - 1 - counter];
                        finalMatrix[row,col] = currentElement;
                        counter++;
                    }
                    else
                    {
                        finalMatrix[row,col] = firstMatrix[row][col];
                        counter = 0;
                    }
                }
            }

            for (int i = 0; i < finalMatrix.GetLength(0); i++)
            {
                int[] currentRow = new int[finalMatrix.GetLength(1)];
                for (int j = 0; j < finalMatrix.GetLength(1); j++)
                {
                    currentRow[j] = finalMatrix[i,j];
                }
                Console.WriteLine("[" + string.Join(", ",currentRow) + "]");
            }
        }
    }
}
