using System;
using System.Linq;

namespace _02._Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] room = new char[n][];

            int row = 0;
            int col = 0;

            for (int i = 0; i < n; i++)
            {
                room[i] = Console.ReadLine().ToCharArray();

                if (room[i].Contains('S'))
                {
                    row = i;
                    col = Array.IndexOf(room[i], 'S');
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                MoveEnemies(room);

                if (room[row].Contains('d') && Array.IndexOf(room[row],'d') > col)
                {
                    room[row][col] = 'X';
                    Console.WriteLine($"Sam died at {row}, {col}");
                    break;
                }
                else if (room[row].Contains('b') && Array.IndexOf(room[row], 'b') < col)
                {
                    room[row][col] = 'X';
                    Console.WriteLine($"Sam died at {row}, {col}");
                    break;
                }

                MoveSam(room, ref row, ref col, directions[i]);

                if (room[row].Contains('N'))
                {
                    int colOfN = Array.IndexOf(room[row], 'N');
                    room[row][colOfN] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    break;
                }
            }

            foreach (var r in room)
            {
                Console.WriteLine(String.Join("",r));
            }
        }

        private static void MoveSam(char[][] room, ref int row, ref int col, char direction)
        {
            room[row][col] = '.';

            switch (direction)
            {
                case 'U':
                    row--;
                    break;
                case 'D':
                    row++;
                    break;
                case 'L':
                    col--;
                    break;
                case 'R':
                    col++;
                    break;
                default:
                    break;
            }

            room[row][col] = 'S';
        }

        private static void MoveEnemies(char[][] room)
        {
            for (int i = 0; i < room.Length; i++)
            {
                int indexD = Array.IndexOf(room[i], 'd');
                int indexB = Array.IndexOf(room[i], 'b');

                if (indexD != -1)
                {
                    if (indexD == 0)
                    {
                        room[i][indexD] = 'b';
                    }
                    else
                    {
                        room[i][indexD] = '.';
                        indexD--;
                        room[i][indexD] = 'd';
                    }
                }
                else if (indexB != -1)
                {
                    if (indexB == room[i].Length - 1)
                    {
                        room[i][indexB] = 'd';
                    }
                    else
                    {
                        room[i][indexB] = '.';
                        indexB++;
                        room[i][indexB] = 'b';
                    }
                }
            }
        }
    }
}
