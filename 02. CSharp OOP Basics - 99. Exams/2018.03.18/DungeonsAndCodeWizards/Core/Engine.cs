using System;
using System.Linq;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] args = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            DungeonMaster dungeonMaster = new DungeonMaster();

            while (!string.IsNullOrEmpty(args[0]) || !dungeonMaster.IsGameOver())
            {
                string output = string.Empty;
                try
                {
                    switch (args[0].ToLower())
                    {
                        case "joinparty":
                            output = dungeonMaster.JoinParty(args);
                            break;
                        case "additemtopool":
                            output = dungeonMaster.AddItemToPool(args);
                            break;
                        case "pickupitem":
                            output = dungeonMaster.PickUpItem(args);
                            break;
                        case "useitem":
                            output = dungeonMaster.UseItem(args);
                            break;
                        case "useitemon":
                            output = dungeonMaster.UseItemOn(args);
                            break;
                        case "givecharacteritem":
                            output = dungeonMaster.GiveCharacterItem(args);
                            break;
                        case "getstats":
                            output = dungeonMaster.GetStats();
                            break;
                        case "attack":
                            output = dungeonMaster.Attack(args);
                            break;
                        case "heal":
                            output = dungeonMaster.Heal(args);
                            break;
                        case "endturn":
                            output = dungeonMaster.EndTurn(args);
                            break;
                        case "isgameover":
                            if (dungeonMaster.IsGameOver())
                            {
                                output = $"\nFinal stats:\n{dungeonMaster.GetStats()}";
                            }
                            break;
                        default:
                            break;
                    }
                    if (dungeonMaster.IsGameOver())
                    {
                        output += $"\nFinal stats:\n{dungeonMaster.GetStats()}";
                        Console.WriteLine(output);
                        return;
                    }
                    Console.WriteLine(output);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine($"Parameter Error: {ae.Message}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"Invalid Operation: {ioe.Message}");
                }

                args = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
        }
    }
}
