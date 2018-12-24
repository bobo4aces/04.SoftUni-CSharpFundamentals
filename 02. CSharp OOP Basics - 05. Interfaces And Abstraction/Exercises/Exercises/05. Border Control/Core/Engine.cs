using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] input = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> ids = new List<string>();

            while (input[0].ToLower() != "end")
            {
                if (input.Length == 3)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    ids.Add(citizen.Id);
                }
                else if (input.Length == 2)
                {
                    Robot robot = new Robot(input[0], input[1]);
                    ids.Add(robot.Id);
                }

                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            string lastDigits = Console.ReadLine();

            ids
                .Where(i => i.Substring(i.Length - lastDigits.Length) == lastDigits)
                .ToList()
                .ForEach(i => Console.WriteLine(i));
        }
    }
}
