using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>();
            Queue<int> locks = new Queue<int>();

            int[] bulletsArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] locksArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < bulletsArr.Length; i++)
            {
                bullets.Push(bulletsArr[i]);
            }

            for (int i = 0; i < locksArr.Length; i++)
            {
                locks.Enqueue(locksArr[i]);
            }

            int intelligence = int.Parse(Console.ReadLine());

            int counter = 0;

            while (true)
            {
                int currentBullet = bullets.Peek();
                int currentLock = locks.Peek();

                counter++;
                bullets.Pop();
                if (currentBullet <= currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (counter == barrelSize && bullets.Count != 0)
                {
                    counter = 0;
                    Console.WriteLine("Reloading!");
                }

                if (locks.Count == 0)
                {
                    int bulletsLeft = bullets.Count;
                    int moneyEarned = intelligence - (bulletsArr.Length - bullets.Count) * bulletPrice;
                    Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
                    break;
                }
                else if (bullets.Count == 0)
                {
                    int locksLeft = locks.Count;
                    Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
                    break;
                }
            }
        }
    }
}
