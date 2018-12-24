using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            string[] itemQuantityPairs = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, Dictionary<string, long>> itemsQuantity = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, long> totals = new Dictionary<string, long>();

            long totalCash = 0;
            long totalGem = 0;
            long totalGold = 0;

            for (long i = 0; i < itemQuantityPairs.Length; i += 2)
            {
                string item = itemQuantityPairs[i];
                long quantity = long.Parse(itemQuantityPairs[i + 1]);
                if (bagCapacity < quantity)
                {
                    continue;
                }
                if (item.Length == 3)
                {
                    if (totalCash + quantity <= totalGem)
                    {
                        AddToDictionary(itemsQuantity, "Cash", item, quantity);
                        if (!totals.ContainsKey("Cash"))
                        {
                            totals.Add("Cash", 0);
                        }
                        totals["Cash"] += quantity;
                        totalCash += quantity;
                    }
                }
                else if (item.ToLower().EndsWith("gem") && item.Length >= 4)
                {
                    if (totalGem + quantity >= totalCash && totalGem + quantity <= totalGold)
                    {
                        AddToDictionary(itemsQuantity, "Gem", item, quantity);
                        if (!totals.ContainsKey("Gem"))
                        {
                            totals.Add("Gem", 0);
                        }
                        totals["Gem"] += quantity;
                        totalGem += quantity;
                    }
                    
                }
                else if (item.ToLower() == "gold")
                {
                    if (totalGold + quantity >= totalGem)
                    {
                        AddToDictionary(itemsQuantity, "Gold", item, quantity);
                        if (!totals.ContainsKey("Gold"))
                        {
                            totals.Add("Gold", 0);
                        }
                        totals["Gold"] += quantity;
                        totalGold += quantity;
                    }
                }
                bagCapacity -= quantity;
            }

            string[] sortedKeys = new string[3];

            foreach (var itemType in totals.OrderByDescending(k => totals.Values.Sum()))
            {
                Console.WriteLine($"<{itemType.Key}> ${totals[itemType.Key]}");
                foreach (var item in itemsQuantity[itemType.Key].OrderByDescending(k => k.Key).ThenBy(v => v.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static void AddToDictionary(Dictionary<string, Dictionary<string, long>> itemsQuantity, string itemType, string item, long quantity)
        {
            if (!itemsQuantity.ContainsKey(itemType))
            {
                itemsQuantity.Add(itemType, new Dictionary<string, long>());
            }
            if (!itemsQuantity[itemType].ContainsKey(item))
            {
                itemsQuantity[itemType].Add(item, 0);
            }

            itemsQuantity[itemType][item] += quantity;
        }
    }
}
