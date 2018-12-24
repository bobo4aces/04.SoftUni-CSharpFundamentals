using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Task03
{
    class Task03
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            char[][] field = new char[fieldSize][];
            int minerRow = 0; 
            int minerCol = 0;
            int coalCount = 0;
            int totalCoals = 0;
            for (int i = 0; i < fieldSize; i++)
            {
                field[i] = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
                if (Array.IndexOf(field[i], 's') != -1)
                {
                    minerRow = i;
                    minerCol = Array.IndexOf(field[i], 's');
                }
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }
            for (int i = 0; i < commands.Length; i++)
            {
                //MoveMiner(field, ref minerRow, ref minerCol, commands[i], coalCount);
                
                bool isInside = IsInside(field, minerRow, minerCol);
                switch (commands[i])
                {
                    case "left":
                        minerCol--;
                        if (!IsInside(field, minerRow, minerCol))
                        {
                            minerCol++;
                        }
                        break;
                    case "right":
                        minerCol++;
                        if (!IsInside(field, minerRow, minerCol))
                        {
                            minerCol--;
                        }
                        break;
                    case "up":
                        minerRow--;
                        if (!IsInside(field, minerRow, minerCol))
                        {
                            minerRow++;
                        }
                        break;
                    case "down":
                        minerRow++;
                        if (!IsInside(field, minerRow, minerCol))
                        {
                            minerRow--;
                        }
                        break;
                    default:
                        break;
                }
                if (field[minerRow][minerCol] == 'c')
                {
                    coalCount++;
                }
                if (totalCoals == coalCount)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    return;
                }
                if (field[minerRow][minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    return;
                }
                field[minerRow][minerCol] = 's';
            }
            Console.WriteLine($"{totalCoals - coalCount} coals left. ({minerRow}, {minerCol})");
        }

        private static bool IsInside(char[][] field, int minerRow, int minerCol)
        {
            if (minerRow < field.Length && minerRow >= 0 &&
                minerCol < field.Length && minerCol >= 0)
            {
                return true;
            }
            return false;
        }

        private static void MoveMiner(char[][] field, ref int minerRow, ref int minerCol, string command, int coalCount)
        {
            
            switch (command)
            {
                case "left":
                    minerCol--;
                    break;
                case "right":
                    minerCol++;
                    break;
                case "up":
                    minerRow--;
                    break;
                case "down":
                    minerRow++;
                    break;
                default:
                    break;
            }
            if (field[minerRow][minerCol] == 'c')
            {
                coalCount++;
            }
            if (field[minerRow][minerCol] == 'e')
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
            }
            field[minerRow][minerCol] = 's';
        }
    }
}
