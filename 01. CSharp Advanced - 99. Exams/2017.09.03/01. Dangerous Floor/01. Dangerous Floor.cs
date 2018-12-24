using System;
using System.Linq;

namespace _01._Dangerous_Floor
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[8][];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
            }
            char[] command = Console.ReadLine().ToCharArray();
            while (string.Join("", command) != "END")
            {
                char pieceType = command[0];
                int currentRow = int.Parse(command[1].ToString());
                int currentCol = int.Parse(command[2].ToString());
                int finalRow = int.Parse(command[4].ToString());
                int finalCol = int.Parse(command[5].ToString());

                if (board[currentRow][currentCol] != pieceType)
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else if (!IsValidMove(pieceType,currentRow,currentCol,finalRow,finalCol))
                {
                    Console.WriteLine("Invalid move!");
                }
                else if (0 <= finalRow && finalRow <= 7 && 0 <= finalCol && finalCol <= 7)
                {

                        char currentPiece = board[currentRow][currentCol];
                        board[currentRow][currentCol] = 'x';
                        board[finalRow][finalCol] = currentPiece;

                    
                    
                }
                else
                {
                    Console.WriteLine("Move go out of board!");
                }
                command = Console.ReadLine().ToCharArray();
            }
        }

        private static bool IsValidMove(char pieceType, int currentRow, int currentCol, int finalRow, int finalCol)
        {
            switch (pieceType)
            {
                case 'K':
                    return (currentRow == finalRow - 1 && currentCol == finalCol - 1) ||
                        (currentRow == finalRow - 1 && currentCol == finalCol) ||
                        (currentRow == finalRow - 1 && currentCol == finalCol + 1) ||
                        (currentRow == finalRow && currentCol == finalCol + 1) ||
                        (currentRow == finalRow && currentCol == finalCol - 1) ||
                        (currentRow == finalRow + 1 && currentCol == finalCol - 1) ||
                        (currentRow == finalRow + 1 && currentCol == finalCol) ||
                        (currentRow == finalRow + 1 && currentCol == finalCol + 1);
                case 'R':
                    //Check for non vacant squares
                    return IsHorizontalOrVerticalMove(currentRow, currentCol, finalRow, finalCol);
                case 'B':
                    return IsDiagonalMove(currentRow, currentCol, finalRow, finalCol);
                case 'Q':
                    return IsHorizontalOrVerticalMove(currentRow, currentCol, finalRow, finalCol) || 
                           IsDiagonalMove(currentRow, currentCol, finalRow, finalCol);
                case 'P':
                    return currentCol == finalCol && currentRow == finalRow + 1;
                case 'x':
                    return true;
                default:
                    return true;
            }
        }

        private static bool IsDiagonalMove(int currentRow, int currentCol, int finalRow, int finalCol)
        {
            bool isRight = currentCol < finalCol;

            if (isRight)
            {
                return currentRow - currentCol == finalRow - finalCol;
            }
            else
            {
                return currentRow + currentCol == finalRow + finalCol;
            }
        }

        private static bool IsHorizontalOrVerticalMove(int currentRow, int currentCol, int finalRow, int finalCol)
        {
            return currentRow == finalRow || currentCol == finalCol;
        }
    }
}
