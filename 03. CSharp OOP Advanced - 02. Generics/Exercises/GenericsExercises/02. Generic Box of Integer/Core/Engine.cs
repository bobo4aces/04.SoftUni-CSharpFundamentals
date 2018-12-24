using _02._Generic_Box_of_Integer.Entities;
using System;

namespace _02._Generic_Box_of_Integer.Core
{
    public class Engine
    {
        public void Run()
        {
            int stringsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stringsCount; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }

    }
}
