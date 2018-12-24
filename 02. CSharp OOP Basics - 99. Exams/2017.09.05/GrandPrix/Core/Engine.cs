using GrandPrix.Entities.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrandPrix.Core
{
    public class Engine
    {
        private RaceTower raceTown;
        public Engine()
        {
            raceTown = new RaceTower();
        }
        public void Run()
        {
            int lapsCount = int.Parse(Console.ReadLine());
            int trackLength = int.Parse(Console.ReadLine());
            for (int i = 0; i < lapsCount; i++)
            {
                List<string> commandArgs = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                string command = commandArgs[0].ToLower();
                string output = string.Empty;
                try
                {
                    switch (command)
                    {
                        case "registerdriver":
                            raceTown.RegisterDriver(commandArgs);
                            break;
                        case "leaderboard":
                            output = raceTown.GetLeaderboard();
                            break;
                        case "completelaps":
                            output = raceTown.CompleteLaps(commandArgs);
                            break;
                        case "box":
                            raceTown.DriverBoxes(commandArgs);
                            break;
                        case "changeweather":
                            raceTown.ChangeWeather(commandArgs);
                            break;
                        default:
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                
            }
            List<Driver> leaderboard = raceTown.drivers
                                        .Where(d => d.CrashReason == null)
                                        .OrderBy(d => d.TotalTime)
                                        .ToList();
            Driver firstPlace = leaderboard[0];
            Console.WriteLine($"{firstPlace.Name} wins the race for {firstPlace.TotalTime:f3} seconds.");
        }
    }
}
