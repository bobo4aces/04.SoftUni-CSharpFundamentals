using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BirthdayCelebrations.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] input = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> birthdays = new List<string>();

            while (input[0].ToLower() != "end")
            {
                if (input.Length == 5)
                {
                    Citizen citizen = new Citizen(
                        input[1], 
                        int.Parse(input[2]), 
                        input[3],
                        input[4]);
                    birthdays.Add(citizen.Birthday);
                }
                else if (input.Length == 3)
                {
                    if (input[0].ToLower() == "robot")
                    {
                        Robot robot = new Robot(input[1], input[2]);
                    }
                    else if (input[0].ToLower() == "pet")
                    {
                        Pet pet = new Pet(input[1], input[2]);
                        birthdays.Add(pet.Birthday);
                    }
                }

                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            string year = Console.ReadLine();

            birthdays
                .Where(i => i.Split("/").Last().ToString() == year)
                .ToList()
                .ForEach(i => Console.WriteLine(i));
        }
    }
}
