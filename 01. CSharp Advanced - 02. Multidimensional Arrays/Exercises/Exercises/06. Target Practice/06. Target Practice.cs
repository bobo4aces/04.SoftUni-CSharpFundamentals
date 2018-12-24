using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stairsDimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int stairsRows = stairsDimensions[0];
            int stairsColumns = stairsDimensions[1];

            Queue<char> snake = new Queue<char>(Console.ReadLine().ToCharArray());

            int[] shotParameters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int impactRow = shotParameters[0];
            int impactCol = shotParameters[1];
            int radius = shotParameters[2];

            char[,] stairs = new char[stairsRows,stairsColumns];

            int counter = 0;

            for (int row = stairsRows-1; row >= 0; row--)
            {
                if (counter % 2 == 0)
                {
                    //Move Right to Left
                    for (int col = stairsColumns - 1; col >= 0; col--)
                    {
                        char currentElement = snake.Dequeue();
                        stairs[row,col] = currentElement;
                        snake.Enqueue(currentElement);
                    }
                }
                else
                {
                    //Move Left to Right
                    for (int col = 0; col < stairsColumns; col++)
                    {
                        char currentElement = snake.Dequeue();
                        stairs[row,col] = currentElement;
                        snake.Enqueue(currentElement);
                    }
                }
                counter++;
            }

            MakeShot(stairs, impactRow, impactCol, radius);
            FixFallingCharacters(stairs);

            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int col = 0; col < stairs.GetLength(1); col++)
                {
                    Console.Write(stairs[row,col]);
                }
                Console.WriteLine();
            }
        }

        static void FixFallingCharacters(char[,] stairs)
        {
            for (int r = stairs.GetLength(0) - 1; r >= 1; r--)
            {
                for (int c = stairs.GetLength(1) - 1; c >= 0; c--)
                {
                    if (stairs[r,c] == ' ')
                    {
                        int index = r - 1;
                        while (stairs[index,c] == ' ' && index > 0)
                        {
                            index--;
                        }
                        stairs[r,c] = stairs[index,c];
                        stairs[index,c] = ' ';
                    }
                }
            }
        }

        static void MakeShot(char[,] stairs, int impactRow, int impactCol, int radius)
        {
            for (int r = 0; r < stairs.GetLength(0); r++)
            {
                for (int c = 0; c < stairs.GetLength(1); c++)
                {
                    bool isInside = CalculateIfPointIsIn(impactRow, impactCol, r, c, radius);
                    if (isInside)
                    {
                        stairs[r,c] = ' ';
                    }
                }
            }
        }

        static bool CalculateIfPointIsIn(int centerY, int centerX, int y, int x, int radius)
        {
            double distance = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));
            if (distance <= radius)
            {
                return true;
            }
            return false;
        }
    }
}
